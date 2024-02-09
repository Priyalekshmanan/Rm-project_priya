import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


const GetClass=()=> {
    
        const [classs, getcls] = useState([])
        const navigate=useNavigate();

        useEffect(() => {
            // if (sessionStorage.getItem("token") != null) {
            //     console.log(sessionStorage.getItem("token"));
            //     const header = {
            //       Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            //     };
     
          
            axios
        .get("http://localhost:5099/api/ClassM/GetAllClass")
        .then((response)=>{
            console.log(response.data);
            getcls(response.data);
        })
        .catch((error)=>{
            console.log(error);
        });
    
    // else{
    //     navigate('/login')
    // }
},[]);
  return (
    <div className='container'>
        <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>ClassId</th>
                    <th>ClassName</th>
                    <th>TeacherId</th>
                    {/* <th>Teacher</th> */}

                </tr>
            </thead>
            <tbody>
               
                  {
                    classs.map((item)=>{
                        return(
                            <tr key={item.classId}>
                                <td>{item.classId}</td>
                                <td>{item.className}</td>
                                <td>{item.teacherid}</td>
                                {/* <td>{item.teacher}</td> */}
                            </tr>
                        )
                    })
                  }
            </tbody>
        </table>
    </div>
  )
  };
  export default GetClass;
