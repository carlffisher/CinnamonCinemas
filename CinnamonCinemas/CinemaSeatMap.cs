using CinnamonCinemas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CinnamonCinemas
{
    public class CinemaSeatMap
    {
        private int noOfSeats;

        private List<SeatRecord> seatrecords = new List<SeatRecord>() {
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


        public CinemaSeatMap()
        {
            noOfSeats = 15;
        }

        public List<SeatRecord> GetCinemaSeatMap()
        {
            return seatrecords;
        }

        public int ReturnNumberOfAvailableSeats()
        {
            return (int) noOfSeats;
        }

        public int UpdateNumberOfAvailabeSeats(int numberSold)
        {
            return noOfSeats -= numberSold;
        }

        public StringBuilder BookSeats(int numberToBook, int numberUnsoldSeats, CinemaSeatMap cinemaSeatMap)
        {
            int DEFAULTNUMBEROFSEATS = 15;
            StringBuilder sb = new StringBuilder("", 30);

            if (numberToBook > numberUnsoldSeats)
            {
                sb.Append("ADVISORY: 001: Insufficient seats available to fulfill booking request: Seats Requested ");
                return (sb);
            }

            sb.Append("ADVISORY: 002: Seats Booked:  ");
            sb.AppendLine("");

            Console.WriteLine(sb);

            for (int j = 1; j <= numberToBook; j++)
            {
                for (int i = 0; i < DEFAULTNUMBEROFSEATS; i++)
                {
                    if (!cinemaSeatMap.seatrecords[i].IsSold)
                    {
                        cinemaSeatMap.seatrecords[i].IsSold = true;
                        noOfSeats--;

                        // concatenate return string here with number of seat sold ...

                        sb.Append("Row: ");
                        sb.Append(cinemaSeatMap.seatrecords[i].Row);
                        sb.Append("  Number: ");
                        sb.Append(cinemaSeatMap.seatrecords[i].Col);
                        sb.AppendLine("");

                        break;
                    }
                }
            }

            return (sb);
        }
    }

    public class SeatRecord
    {
        public int  Col { get; set; }
        public char Row { get; set; }
        public bool IsSold { get; set; }
    }
}
