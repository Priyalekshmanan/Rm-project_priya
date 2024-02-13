import axios from 'axios'
import React, { useState } from 'react'

export default function GetAllUser() {
    const [user, setUser] = useState([]);
  
    //const [userId, setuserId] = useState('');
    // const GetById=()=>{
    //     axios.get(""+userId)
    //     .then((res)=>{
    //         console.log(res.data);
    //         setUser(res.data);
    //     })
    //     .catch((err)=>{
    //         console.log(err);
    //     });
    // }
   
    const GetAll=()=>{
        axios
        .get("http://localhost:5099/api/Users/GetAllUsers")
        .then((res)=>{
            console.log(res.data);

            setUser(res.data);
        })
        .catch((err)=>{
            console.log("error in fetching user",err);
            alert("error in fetching");
        })
    }

   
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
        <div className='container'>
        {/* <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input value={userId}
                            onChange={(e) => setuserId(e.target.value)}
                            type="text"
                            placeholder="Enter  ID"
                        />
                       
                    </div>
                    <button onClick={GetById} className="btn btn-success ms-2" type="submit">
                        View
                    </button>
                  
                </form> */}
        <table  className="table table-striped">
            <thead>
           
                <tr>
                    <th>UserId</th>
                    <th>UserName</th>
                   
                    <th>Role</th>
                </tr>
                </thead>
                <tbody>
                    {user.map((item,index)=>(
                        <tr key={index}>
                            <td>{item.userId}</td>
                            <td>{item.userName}</td>
                         
                            <td>{item.role}</td>
                              
                            {/* <td> <button value={item.userId}  onClick={Delete} type="button">Delete</button></td> */}
                        </tr>
                    )
                    )}
                </tbody>

        </table>
        </div>
        <button onClick={GetAll} type="button">GetAll</button>
       

    </div>
  )
}

