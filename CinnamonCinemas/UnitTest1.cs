using NUnit.Framework;
using FluentAssertions;
using CinnamonCinemas;
using System.Text;

namespace CinnamonCinemas
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void CreateASeatMap()
        {
            // So, lets create a defult 3 row by 5 seat cinema seat test model map and check it matches the one created and returned ...

            List<SeatRecord> testseatrecords = new List<SeatRecord>() {
                    new SeatRecord(){ Col = 1, Row = 'A', IsSold = false},
                    new SeatRecord(){ Col = 2, Row = 'A', IsSold = false},
                    new SeatRecord(){ Col = 3, Row = 'A', IsSold = false},
                    new SeatRecord(){ Col = 4, Row = 'A', IsSold = false},
                    new SeatRecord(){ Col = 5, Row = 'A', IsSold = false},
                    new SeatRecord(){ Col = 1, Row = 'B', IsSold = false},
                    new SeatRecord(){ Col = 2, Row = 'B', IsSold = false},
                    new SeatRecord(){ Col = 3, Row = 'B', IsSold = false},
                    new SeatRecord(){ Col = 4, Row = 'B', IsSold = false},
                    new SeatRecord(){ Col = 5, Row = 'B', IsSold = false},
                    new SeatRecord(){ Col = 1, Row = 'C', IsSold = false},
                    new SeatRecord(){ Col = 2, Row = 'C', IsSold = false},
                    new SeatRecord(){ Col = 3, Row = 'C', IsSold = false},
                    new SeatRecord(){ Col = 4, Row = 'C', IsSold = false},
                    new SeatRecord(){ Col = 5, Row = 'C', IsSold = false},
                };

            CinemaSeatMap cinemaseatmap = new();

            var cinemaseatrecord = cinemaseatmap.GetCinemaSeatMap();

            cinemaseatmap.GetCinemaSeatMap().Should().BeEquivalentTo(testseatrecords);

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Index, Col, Row, ISold: {0} {1} {2} {3}", i, cinemaseatrecord[i].Col, cinemaseatrecord[i].Row, cinemaseatrecord[i].IsSold);
                cinemaseatrecord[5].IsSold = true;
                Console.WriteLine("Index, Col, Row, ISold: {0} {1} {2} {3}", i, cinemaseatrecord[i].Col, cinemaseatrecord[i].Row, cinemaseatrecord[i].IsSold);
            }
        }

        [Test]
        public void UpdateAvailableSeats()
        {
            // firstly, check we've the default number of seats for sale, which should be 15 ...

            int DEFAULTNUMBEROFSEATS = 15;

            CinemaSeatMap cinemaseatmap = new();
            cinemaseatmap.GetCinemaSeatMap();

            cinemaseatmap.ReturnNumberOfAvailableSeats().Should().Be(DEFAULTNUMBEROFSEATS);

            //now, let's check we can decrement the number of seats available for sale ...

            cinemaseatmap.UpdateNumberOfAvailabeSeats(3).Should().Be(12);
        }

        [Test]
        public void SellSeats()
        {
            // Now, in a loop, generate a random number between 1 and 3, and book seats accordingly. 
            // This booking must begin at Row A and move from low to high seat numbers in the Rows.
            // When requested booking exceeds number of seats left available, return advisement to that effect, no seats a thus booked.
            // Finally, advise when all seats are sold and exit ...

            string BookingReturnString;
            int NoOfUnsoldSeats;

            CinemaSeatMap cinemaseatmap = new();
            
            do // while there are unsold seats
            {
                cinemaseatmap.GetCinemaSeatMap();

                Random rnd = new Random();

                int NoOfSeatsRequested = rnd.Next(1, 4);

                Console.WriteLine("NoOfSeatsRequested: {0}", NoOfSeatsRequested);
                NoOfUnsoldSeats = cinemaseatmap.ReturnNumberOfAvailableSeats(); // Passed previous test

                if (NoOfUnsoldSeats == 0)
                {
                    Console.WriteLine("All seats sold");

                    
                    break;
                }
                else
                {
                    Console.WriteLine("NumberOfAvailabeSeats: {0}", NoOfUnsoldSeats);

                    StringBuilder StatusOfBooking = cinemaseatmap.BookSeats(NoOfSeatsRequested, NoOfUnsoldSeats, cinemaseatmap);
                    BookingReturnString = StatusOfBooking.ToString();

                    BookingReturnString.Should().StartWith("ADVISORY"); // Valid transactions attempts return a string starting with "ADVISORY" ...

                    if (BookingReturnString.Equals("ADVISORY: 001"))
                    {
                        // Console.WriteLine("Insufficient seats available to fulfill booking request: Seats Requested {0}, Seats Available {1}", NoOfSeatsRequested, NoOfUnsoldSeats);

                        Console.WriteLine("Seats Requested {0}, Seats Available {1}", NoOfSeatsRequested, NoOfUnsoldSeats);
                    }
                    else
                    {
                        Console.WriteLine("statusOfBooking: {0}", StatusOfBooking);
                        cinemaseatmap.ReturnNumberOfAvailableSeats(); // Previously tested successfully
                        Console.WriteLine("ReturnNumberOfAvailableSeats: {0}", cinemaseatmap.ReturnNumberOfAvailableSeats());
                    }
                }
            } while (NoOfUnsoldSeats > 0);
        }
    }
}