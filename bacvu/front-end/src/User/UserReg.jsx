import axios from 'axios';
import React, { useState } from 'react'

export default function UserReg() {

    const [userId, setUserId] = useState("");
    const [role, setRole] = useState("");
    const [data,setUser]= useState({})

    const AddUser=()=>{
        alert("")
        let user={
            userId:userId,
            role:role,
            userName:"na",
            password:"3"
        }
        console.log(user);
        axios
       
        .post("http://localhost:5099/api/Users/Adduser",user)
        .then((res)=>{
            console.log(res.data);
            setUser(res.data);   
        })
        .catch((err)=>{
            console.log("error in adding user",err);
            alert("error in adding");
        })
    }

  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
        <label for = "user">UserId</label>
        <input type='text' id='user' value={userId} onChange={(e)=>setUserId(e.target.value)}></input>
        <div class="form-outline mb-4">
                  <select className="form-control form-control-lg" value={role} onChange={e => setRole( e.target.value )} >
                    <option value="">Role</option>
                    <option value="Teacher">Teacher</option>
                    <option value="Student">Student</option>
                  </select>
                </div>
                <button onClick={AddUser} type="button">AddUser</button>

    </div>
  )
}
