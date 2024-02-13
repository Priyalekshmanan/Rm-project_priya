import axios from 'axios'
import { Link, Outlet, useNavigate } from 'react-router-dom';
import React, { useEffect, useState } from 'react'


export default function TeacherProfile() {
    let id=sessionStorage.getItem("uid")
    const [teachers, setTeachers] = useState({})
    const navigate=useNavigate()
    useEffect(() => {
        if (sessionStorage.getItem("token") != null) {
            console.log(sessionStorage.getItem("token"));
            const headers = {
              Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            };
      axios
      .get("http://localhost:5099/api/Teacher/getTeachersByTheirId/"+id,{headers})
      .then((response)=>{
        console.log(response.data);
        setTeachers(response.data);
        
      })
      .catch((error)=>{
        console.log(error);
      });
    }
    else{
        navigate("/login")
    }
    }, []);
    
    
  return (

    <div className='main-content position-relative max-height-vh-100 h-100 border-radius-lg'>
        <h2>Profile</h2>
        <table className='table table-striped'>

            <tbody>
                <tr>
                    <td>TeacherId : </td>
                    <td>{id}</td>
                </tr>
                <tr>
                    <td>Name : </td>
                    <td>{teachers.teacherFirstName+" "+teachers.teacherLastName}</td>
                </tr>
                <tr>
                    <td>Email : </td>
                    <td>{teachers.teacherEmail}</td>
                </tr>
                <tr>
                    <td>Phone number : </td>
                    <td>{teachers.teacherPhone}</td>
                </tr>
                <tr>
                    <td>Gender : </td>
                    <td>{teachers.teacherGender}</td>
                </tr>
                <tr>
                    <td>Date Of Birth : </td>
                    <td>{teachers.dateOfBirth}</td>
                </tr>
                <tr>
                    <td>Address: </td>
                    <td>{teachers.teacherAddress}</td>
                </tr>
               
                

                
            </tbody>
        </table>
        <div className="mt-3">
                            <Link to="teacher-profile/edit-profile" className="btn btn-primary">Edit Details</Link>
                        </div>
                        <Outlet />
    </div>
  )
}
