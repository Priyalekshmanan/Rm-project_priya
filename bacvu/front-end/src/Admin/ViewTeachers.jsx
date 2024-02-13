
import axios from 'axios';
import React, { useState } from 'react'

export default function ViewTeachers() {
    const [teachers, setTeachers] = useState([]);
    const [userId, setuserId] = useState('');

    const GetById=()=>{
        axios.get("http://localhost:5099/api/Teacher/getTeachersByTheirId/"+userId)
        .then((res)=>{
            console.log(res.data);
            setTeachers(res.data);
        })
        .catch((err)=>{
            console.log(err);
        });
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
    
    const Delete=(index,e)=>{
      axios.delete("http://localhost:5099/api/Teacher/deleteTeacherById/"+index)
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
                        <input value={userId}
                            onChange={(e) => setuserId(e.target.value)}
                            type="text"
                            placeholder="Enter ID"
                        />
                       
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
            {teachers.map((item,index)=>(
                <tr key={index}>
                    <td> {item.teacherId} </td>
                    <td> {item.teacherFirstName+" "+item.teacherLastName} </td>
                    <td> {item.dateOfBirth} </td>
                    <td> {item.teacherGender} </td>
                    <td> {item.teacherSubjectTaught} </td>
                    <td> {item.teacherEmail} </td>
                    <td><button onClick={(e) => Delete(item.teacherid,e)}>Delete</button></td> 
                </tr>
            )
            )}
        </tbody>
      </table>
      <button  onClick={GetTeachers} type="button"  className="btn btn-outline-primary">View Teachers</button>
      
    </div>
    
  )
}

// import axios from 'axios';
// import React, { useState } from 'react';

// export default function ViewResult() {
//     const [mark, setMark] = useState([]);
//     const [exmId, setExmdId] = useState('');
//     const [stuID, setStuId] = useState('');
//     const [exmIdError, setExmIdError] = useState('');
//     const [stuIdError, setStuIdError] = useState('');

//     const GetResultBYExamIdndStuID = (e) => {
//         e.preventDefault(); // Prevent default form submission behavior

//         // Reset errors
//         setExmIdError('');
//         setStuIdError('');

//         // Validation
//         let isValid = true;
//         if (!exmId) {
//             setExmIdError('Exam ID is required');
//             isValid = false;
//         }
//         if (!stuID) {
//             setStuIdError('Student ID is required');
//             isValid = false;
//         }

//         if (isValid) {
//             axios
//                 .get(`http://localhost:5099/api/Result/GetByExamIdNStudentId/af/w${exmId}/${stuID}`)
//                 .then((response) => {
//                     setMark(response.data);
//                     console.log(response.data);
//                 })
//                 .catch((error) => {
//                     console.error('Error retrieving results:', error);
//                     alert('Error retrieving results. Please try again.');
//                 });
//         }
//     };

//     const GetAllResults = () => {
//         axios
//             .get("http://localhost:5099/api/Result/GetAllResult")
//             .then((response) => {
//                 setMark(response.data);
//                 console.log(response.data);
//             })
//             .catch((error) => {
//                 console.error('Error retrieving all results:', error);
//                 alert('Error retrieving all results. Please try again.');
//             });
//     };

//     return (
//         <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
//             <div className="container">
//                 <form className="d-flex justify-content-end">
//                     <div className="mb-3">
//                         <input
//                             onChange={(e) => setExmdId(e.target.value)}
//                             type="text"
//                             className={`form-control ${exmIdError && 'is-invalid'}`}
//                             placeholder="Enter Exam ID"
//                         />
//                         {exmIdError && <div className="invalid-feedback">{exmIdError}</div>}
//                     </div>
//                     <div className="mb-3">
//                         <input
//                             onChange={(e) => setStuId(e.target.value)}
//                             type="text"
//                             className={`form-control ${stuIdError && 'is-invalid'}`}
//                             placeholder="Enter Student ID"
//                         />
//                         {stuIdError && <div className="invalid-feedback">{stuIdError}</div>}
//                     </div>
//                     <button onClick={GetResultBYExamIdndStuID} className="btn btn-primary" type="submit">
//                         View
//                     </button>
//                 </form>

//                 <table className="table table-striped">
//                     <thead>
//                         <tr>
//                             <th>Exam Id</th>
//                             <th>Student Id</th>
//                             <th>Subject Id</th>
//                             <th>Mark</th>
//                         </tr>
//                     </thead>
//                     <tbody>
//                         {mark.map((item, index) => (
//                             <tr key={index}>
//                                 <td>{item.examId}</td>
//                                 <td>{item.studentId}</td>
//                                 <td>{item.subjectId}</td>
//                                 <td>{item.marks}</td>
//                             </tr>
//                         ))}
//                     </tbody>
//                 </table>
//             </div>
//             <button onClick={GetAllResults} type="button" className="btn btn-outline-primary">
//                 Get all
//             </button>
//         </div>
//     );
// }
