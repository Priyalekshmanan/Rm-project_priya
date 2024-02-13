
import axios from 'axios';
import React, { useState } from 'react'

export default function ViewTeachers() {
    const [teachers, setTeachers] = useState([]);
    const [userId, setuserId] = useState('');
    const [teacherById,setTeacherById]=useState({})
    const [iderrors, setIdErrors] = useState('');

    const GetById=(e)=>{
        e.preventDefault(); // Prevent default form submission behavior
   
        // // Reset errors
        setIdErrors('');
       
        // // Validation
        let isValid = true;
        // if (!iderrors) {
            if(userId.trim()===''){
            setIdErrors('Teacher id is required');
            isValid = false;
        }
       
         if (isValid) {
        
        axios.get("http://localhost:5099/api/Teacher/getTeachersByTheirId/"+userId)
        .then((res)=>{
            console.log(res.data);
            setTeacherById(res.data)
        })
        .catch((err)=>{
            console.log(err);
        });
    }
}
    

    const GetTeachers=()=>{
        axios
        .get("http://localhost:5099/api/Teacher/getAllExistingTeachers")
        .then((response)=>{
            console.log(response.data);
            setTeachers(response.data);
           
        })
        .catch((error)=>{console.log("Error in retreiving techers " ,error);
        alert("Error  in retrieving teachers");
    });
    }
    
    const Delete=(item)=>{
      axios.delete("http://localhost:5099/api/Teacher/deleteTeacherById/"+item)
      .then((res)=>{
          console.log(res.data);
         // e.target.deleteRow(index)
         // setuserId(res.data);
          alert("deleted successfully")
          window.location.reload();

      })
      .catch((err)=>{
          console.log("error in fetching user",err);
          alert("error in fetching");
      })

  }

    
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
         <form className="d-flex justify-content-end"> 
                    <div className="mb-3">
                        <input 
                            onChange={(e) => setuserId(e.target.value)}
                            type="text"
                            className={`form-control ${iderrors && 'is-invalid'}`}
                            placeholder="Enter ID"
                        />
                          {iderrors && <div className="invalid-feedback">{iderrors}</div>}
                       
                    </div>
                    <button onClick={GetById} className="btn btn-success ms-2" type="submit">
                        View
                    </button>
                  
                </form>  
       
      <table  className="table table-striped">
        <thead>
            <tr>
                <th>TeacherId</th>
                <th>Name</th>
                <th>DOB</th>
                <th>Gender</th>
                <th>Subject</th>
                <th>Email</th>
            </tr>
        </thead>
        <tbody>
        {teacherById.teacherId?(
            <tr key={teacherById.teacherId}>
                    <td> {teacherById.teacherId} </td>
                    {teacherById.teacherId?<td> {teacherById.teacherFirstName+" "+teacherById.teacherLastName} </td>:""}
                    <td> {teacherById.dateOfBirth} </td>
                    <td> {teacherById.teacherGender} </td>
                    <td> {teacherById.teacherSubjectTaught} </td>
                    <td> {teacherById.teacherEmail} </td>
                    {teacherById.teacherId?<td><button onClick={(e) => Delete(teacherById.teacherId)}>Delete</button></td>:""}
            </tr>
        ):(
            teachers.map((item,index)=>(
                <tr key={index}>
                    <td> {item.teacherId} </td>
                    <td> {item.teacherFirstName+" "+item.teacherLastName} </td>
                    <td> {item.dateOfBirth} </td>
                    <td> {item.teacherGender} </td>
                    <td> {item.teacherSubjectTaught} </td>
                    <td> {item.teacherEmail} </td>
                    <td><button onClick={(e) => Delete(item.teacherId)}>Delete</button></td> 
                </tr>
                
            )
            ))}
            
        </tbody>
      </table>
      <button  onClick={GetTeachers} type="button"  className="btn btn-outline-primary">View Teachers</button>
    </div>
    
  )
}


