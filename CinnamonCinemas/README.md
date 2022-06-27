# CinnamonCinemas

In this simple solution there is a Class called CinemaSeatMap which is invoked by an app - the Test app in this case - which creates and returns
a cinema seating map, fixed at the default of 3 rows of 5 seats. In a more comprehensive solution, this Class would be able to generate one or more
seating maps of arbitrary size, perhaps being declared as an abstract interface class. This would allow the creation of many seating maps for each of
Cinnamon Cinemas auditoria.

Class CinemaSeatMap also contains all the methods to update retrieve and otherwise maintain the seating map throught the course of the
instantiating application.

This map is used by the method BookSeats(int numberToBook, int numberUnsoldSeats, CinemaSeatMap cinemaSeatMap), which is a method of the
CinemaSeatMap Class. BookSeats receives the number of seats requested by a customer, the current number of unsold seats and the current
cinema seat map which was returned to the calling application on creation.

BookSeats works through the whole map for each booking request, searching for an unsold seat record. When found, the record is marked 'sold'
and the seat number - together with others in that group of requests - is returned to the calling app as a stringbuilder string. Otherwise, a similar
string declaring there are insufficient seats to fulfill the booking request is returned. In this case no seats are sold.

In this way, the seating plan eventually becomes fully occupied - all seats being marked as sold; the app is duly advised and exits.

The code has been left with console diagnostic output for the convenience of the observer.


