import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'


const GetExam=()=> {
    
        const [exam, getExam] = useState([])
        const navigate=useNavigate();

        useEffect(() => {
            // if (sessionStorage.getItem("token") != null) {
            //     console.log(sessionStorage.getItem("token"));
            //     const header = {
            //       Authorization: `Bearer ${sessionStorage.getItem("token")}`,
            //     };
     
          
            axios
        .get("http://localhost:5099/api/Exam/GetAllExam")
        .then((response)=>{
            console.log(response.data);
            getExam(response.data);
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
                    <th>ExamId</th>
                    <th>ExamName</th>
                    <th>ExamTime</th>
                    <th>Date</th>
                    <th>ClassId</th>
                    <th>SubId</th>
                    {/* <th>ClassMan</th>
                    <th>Subject</th> */}


                </tr>
            </thead>
            <tbody>
               
                  {
                    exam.map((item)=>{
                        return(
                            <tr key={item.examId}>
                                <td>{item.examId}</td>
                                <td>{item.examName}</td>
                                <td>{item.examTime}</td>
                                <td>{item.date}</td>
                                <td>{item.classId}</td>
                                <td>{item.subId}</td>
                                {/* <td>{item.ClassMan}</td>
                                <td>{item.Subject}</td> */}
                            </tr>
                        )
                    })
                  }
            </tbody>
        </table>
    </div>
  )
  };
  export default GetExam;
