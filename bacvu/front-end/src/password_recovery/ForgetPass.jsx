

import React, { useRef,useState } from 'react';
import emailjs from '@emailjs/browser';
import SendIcon from '@mui/icons-material/Send';
import Button from '@mui/material/Button';
import { Link } from 'react-router-dom';
// import NewPassword from './NewPassword';

// import './comm.css';

 const Forget = () => {
  const form = useRef();

  const sendEmail = (e) => {
    e.preventDefault();

    emailjs
      .sendForm('service_r4b41io', 'template_r3rbgdx', form.current, {
        publicKey: 'O4LELxTLy0MLjIw-s',
      })
      .then(
        () => {
          console.log('SUCCESS!');
        },
        (error) => {
          console.log('FAILED...', error.text);
        },
      );
  };

  return (
    <div className='email'>
    <form ref={form} onSubmit={sendEmail} className="contact__form">
       <label>Enter UserId:</label>
      <input type="text" name="name"  className="email__from" placeholder="************"/>
      <label>Enter EmailId:</label>
      <input type="email" name="email"  className="email__from" placeholder="person@example.com"/>
     
   <button type='submit'>Send</button>
   
   </form>
    </div>
  );
};
export default Forget;