// Post New Internship
// data from form => NewInternshipModel will be passed into the application handler
// the application handler will call the service interface and send the data
// the service will convert the data into a request object and make api call
// service will wait and return the new created internship 
// application will convert it into ui model
// ui will render the component with data

// Get internship by id
// data from a list => id will be passed into the application handler
// application will call service interface and send the id
// no mapping required to do before sending request
// after request sent and awaited , service returns the result
// application will convert into ui model
// ui will render the component