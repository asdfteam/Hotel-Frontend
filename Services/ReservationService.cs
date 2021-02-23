using System.Threading.Tasks;
using Hotel_Frontend.Models;
using HttpClientImpl;
using Microsoft.AspNetCore.Components;

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
        public ReservationModel GetReservation();
        public Task CreateReservation(ReservationModel model);
        public Task PostReservation(int customerid);
    }
    public class ReservationService : IReservationService
    {
        public ReservationModel Reservation { get; set; }
        private NavigationManager _navigationManager;
        private IHttpClientImpl _httpClientImpl;
        public ReservationService(NavigationManager navigationManager, IHttpClientImpl httpClientImpl)
        {
            _navigationManager = navigationManager;
            _httpClientImpl = httpClientImpl;
        }

        public void SetReservation(ReservationModel reservation)
        {
            Reservation = reservation;
        }

        public ReservationModel GetReservation()
        {
            return Reservation;
        }

        public Task CreateReservation(ReservationModel model)
        {
            throw new System.NotImplementedException();
        }

        public Task PostReservation(int customerid)
        {
            throw new System.NotImplementedException();
        }
    }
}