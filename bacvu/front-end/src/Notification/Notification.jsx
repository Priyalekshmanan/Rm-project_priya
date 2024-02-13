import React, { useState } from "react";
import "./Notification.css";
import axios from "axios";
// import '../../node_modules/bootstrap/dist/css/bootstrap.min.css';

const NotificationForm = () => {
  const [notificationId, setId] = useState("");
  const [message, setMessage] = useState("");
  const [date, setDate] = useState("");
  const [role, setRole] = useState("");

  const validateForm = () => {
    return notificationId.length > 0 && message.length > 0 && date.length > 0 && role.length > 0;
  }

  const Save = (e) => {
    alert("save")
 
    // if (validateForm()) {
      let notification = {
        notificationId: notificationId,
        message: message,
        date: "2024-02-12T07:12:45.192Z",
        role: role
      };
      axios
        .post("http://localhost:5099/api/Notification/AddNotification", notification)
        .then((response) => {
          console.log(response.data);
        })
        .catch((error) => console.log(error));
    // } else {
    //   alert("Please fill in all fields");
    // }
  };

  return (
    <div className="email-form">
      <h1>Send a Message </h1>

      <div>
        {/* <label htmlFor="email">NotificationId</label>
        <input
          value={notificationId}
          onChange={(e) => setId(e.target.value)}
        /> */}
        <label htmlFor="message">Message</label>
        <textarea
          placeholder="Enter your message here..."
          value={message}
          name="message"
          onChange={(e) => setMessage(e.target.value)}
        />
        {/* <label htmlFor="email" spacing={4}> date</label>
        <input
          value={date}
          onChange={(e) => setDate(e.target.value)}
        /> */}
        <div value={role}>
          <h1>Select Recipients   </h1>
          <label className="container1">Teacher
            <input type="checkbox" value="teacher" onChange={(e) => setRole(e.target.value)} />
            <span className="checkmark"></span>
          </label>
          <label className="container1">Students
            <input type="checkbox" value="students" onChange={(e) => setRole(e.target.value)} />
            <span className="checkmark"></span>
          </label>
          <label className="container1"> All Users
            <input type="checkbox" value="AllUsers" onChange={(e) => setRole(e.target.value)} />
            <span className="checkmark"></span>
          </label>
        </div>
        <button  onClick={Save}>
          Send Message
        </button>
        </div>
    </div>
  );
};

export default NotificationForm;