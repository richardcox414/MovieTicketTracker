Online Movie Ticket Booking Web Site
Using AngularJS, Web API, MVC, Bootstrap, Code First, EF
This is a school project - still not 100% complete. Always hard to revisit school projects from some reason.
Xamarin done by Lance & Robert
# # Requirements Specification # #
2. Admins
    a. Create
    b. Manage theaters through a management portal

3. Movies are pulled in from OMDb API at time of movie scheduling

4. Movies show in different theaters at different times

5. Managers AND admins can:
    a. Create
    b. Manage theater schedules

6. Management of
    a. Seating
    b. Theaters
    c. ShowTimes
    are done on a web based portal that should be responsive

7. Theaters can play any movies that can fit during open hours

8. Customers approach a kiosk at the front to purchase tickets

9. Customers select a
    a. Movie
    b. ShowTime
    from available options

10. Customer can select a number of
    a. Child
    b. Adult
    c. Senior tickets

11. Prices are configurable by Admins

12. Prices are the same for all movies

13. Prices for showings before noon have a different price (matinee)

14. If the layout has 50 seats, then only 50 tickets for that ShowTime should be sold in total

15. After selecting seats, assume that the customer is able to provide payment, and prompt them
for an optional email for a receipt

16. On screen, display a:
    a. Confirmation code
    b. Theater number
    c. ShowTime
    d. Movie
    e. Seats, etc.

17. On that same screen QR code should be generated

18. The QR should link
    https://en.wikipedia.org/wiki/QR_code#URLs
    to a confirmation web page that shows the same detailed information on a responsive page for
    a smart phone

19. This App displays the
    a. Movies and ShowTimes +
    b. The number of seats remaining +
    c. Ratings
    d. Movie description
    e. Runtime, etc. (think “what do I normally see on rotten tomatoes / IMDB / etc.”)

20. The App should support a “scan your code” for the above QR code for fast / native display

21. The app should allow for:
    a. Detailed movie review
    b. Ratings by users

22. In order the give a movie a rating, the user must have scanned a ticket QR for that movie - one
review per purchase max

23. The App should save all previously scanned QR codes and display them to the user in a list so
they can show off how often they see movies

24. Admins and managers should be able to see a table of all purchases made by:
    a. Chronological order
    b. Search
    c. Filter / etc in some useful way