using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Hotel_Frontend.Models;
using HotelLibrary;
using HttpClientImpl;
using Microsoft.AspNetCore.Components;
using Newtonsoft.Json;

namespace Hotel_Frontend.Services
{

    public interface IReservationService
    {
        /*
         * Use case: A customer trying to create a new reservation while not logged in, must either log in or register.
         * This service serves as a cache for the created reservation.
         */
        public ReservationModel Reservation { get; set; }
        public void SetReservation(ReservationModel reservation);
        public Task<List<Reservation>> GetReservation(int customerid);
        public Task PostReservation(int customerid, ReservationModel model);

        public Task PostStatus(int roomid, string note);
    }
    public class ReservationService : IReservationService
    {
        public ReservationModel Reservation { get; set; }
        private IHttpClientImpl _httpClientImpl;
        public ReservationService(IHttpClientImpl httpClientImpl)
        {
            _httpClientImpl = httpClientImpl;
        }

        public void SetReservation(ReservationModel reservation)
        {
            Reservation = reservation;
        }

        public async Task<List<Reservation>> GetReservation(int customerid)
        {
            var fixedUri = $"http://localhost:5000/reservations/{customerid}";
            var response = await _httpClientImpl.Get(fixedUri);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            var result = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<List<Reservation>>(result);
        }

        public async Task PostReservation(int customerid, ReservationModel model)
        {
            var fixedUri = $"http://localhost:5000/reservations/{customerid}";
            var jsonModel = JsonConvert.SerializeObject(model);
            var response = await _httpClientImpl.Post(fixedUri, jsonModel);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
            Reservation = null;
        }

        public async Task PostStatus(int roomid, string note)
        {
            var FixedUri = $"http://localhost:5000/rooms/{roomid}?newStatus=SERVICE&note={note}";
            var response = await _httpClientImpl.Put(FixedUri);
            if (!response.IsSuccessStatusCode) throw new Exception(response.ReasonPhrase);
        }
    }
}