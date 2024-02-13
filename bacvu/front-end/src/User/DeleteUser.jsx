import { getByPlaceholderText } from '@testing-library/react';
import axios from 'axios';
import React, { useState } from 'react'


export default function DeleteUser() {
    const [userId, setUserId] = useState("")
    const[userIdError,setUserIdError]= useState("")
    
    const Delete=()=>{
      setUserIdError('');
      //validation
      let isValid=true;
      if(!userId.trim()){
        setUserIdError('Userid is required');
        isValid=false;
      }
      if(isValid){

     
        axios.delete("http://localhost:5099/api/Users/DeleteUser/"+userId)
        .then((res)=>{
            console.log(res.data);  
           // setuserId(res.data);
            alert("deleted successfully")

        })
        .catch((err)=>{
            console.log("error in fetching user",err);
            alert("error in fetching");
        });

    }
  };

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
    <div>DeleteUser</div>
    <label for ="deleting">UserId:</label>
    <input type='text' value={userId} onChange={(e)=>setUserId(e.target.value)} placeholder='enter id' />
    {userIdError && <div style={{color : 'red'}}>{userIdError}</div>}
    <button type="button" onClick={Delete}>Delete</button>
  
    </div>

  )
}
