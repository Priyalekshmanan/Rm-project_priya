import React, { useRef,useState,useEffect } from 'react';
// import './comm.css';
import SendIcon from '@mui/icons-material/Send';
import Button from '@mui/material/Button';
import emailjs from '@emailjs/browser';
import axios from 'axios';


  const NewPassword=()=> {
    const Email = sessionStorage.getItem("userMail")
    const ID= sessionStorage.getItem("userId")
    const [userOb,getUser] = useState({})
    const [Npassword,setPassword] = useState('')
   

    useEffect(()=>{axios 
      .get("http://localhost:5099/api/Users/getUserById/"+ID)
      .then((res)=>{
        getUser(res.data)
      })
      .catch((e)=>{
        console.log(e);
      })
  

    },[])


    
    console.log(Email);
    const form = useRef();
  
    const sendEmail = (e) => {
      e.preventDefault();

      let userObj = {
        userId:userOb.userId,
        userName:userOb.userName,
        password:Npassword,
        role:userOb.role


      }
      axios
      .put("http://localhost:5099/api/Users/EditUser",userObj)
      .then((res)=>{
        console.log(res.data);
      })
      .catch((e)=>{
        console.log(e);
      })
  
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
       <form ref={form} className="contact__form" >
    <input name="email" value={Email} className="d-none" />
    <label >New Password:</label>
    <input type="password" name="email"  className="email__from" onChange={(e)=>setPassword(e.target.value)}/>
    <label >Confirm Password:</label>
    <input type="password" name="useremail" id="emailFrom"  className="email__from" />
    <input onClick={sendEmail} type="button" value="Send" endIcon={<SendIcon />} className="submit__btn" />
  </form></div>
   
  )
};
export default NewPassword;
