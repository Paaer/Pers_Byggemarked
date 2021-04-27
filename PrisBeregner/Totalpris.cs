using ClassLibrary_Byggemarked;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication_Byggemarked.PrisBeregner
{
    public class Totalpris
    {
        private ByggemarkedRigtigEntities db = new ByggemarkedRigtigEntities();

    

    public double Udregner(BookingSet booking)
    {
            var produkt = db.VærktøjskatalogSet.Find(booking.Værktøjskatalog_Navn);
            double depositum = (produkt.Depositum);
            double dagspris = (produkt.Døgnpris);
            double pris = 0;
            pris = ((udregnAntalDage(booking) * dagspris) + depositum);
            return pris;
    }

        public double udregnAntalDage(BookingSet booking)
    {
            double antaldage = (booking.SlutBooking - booking.StartBooking).TotalDays;
            return antaldage;
    }

        public static double udregnAntalDageTest(BookingSet booking)
        {
            double antaldage = (booking.SlutBooking - booking.StartBooking).TotalDays;
            return antaldage;
        }

        public static double UdregnerTest(BookingSet booking, VærktøjskatalogSet værktøj)
        {
            var produkt = værktøj;
            double depositum = (produkt.Depositum);
            double dagspris = (produkt.Døgnpris);
            double pris = 0;
            pris = ((udregnAntalDageTest(booking) * dagspris) + depositum);
            return pris;
        }


    }
}