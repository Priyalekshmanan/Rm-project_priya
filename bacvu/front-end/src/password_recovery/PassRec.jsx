import axios from 'axios';
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom';

export default function PassRec() {
    const[student,setStudent] = useState({})
    const[teacher,setTeacher] = useState({})

    const[usr_id,setSid] = useState("")
    const[sMail,setMail] = useState("")
    const[phone,setPhone] = useState("")
    const[user,setUser] = useState({})
    const navigate=useNavigate()
    
 
         const chnagpassVal = (e) => {
          axios
      .get("http://localhost:5099/api/Users/getUserById/"+usr_id)
      .then((res)=>{
        console.log(res.data);
        setUser(res.data)
    
      })
      .catch((error) => console.log(error));
      console.log("Role="+user.role);
        if(user.role =="Student"){
            axios
            .get("http://localhost:5099/api/Student/GetStudentById/"+usr_id)
        .then((response) => {
          setStudent(response.data)
          
        })
        .catch((error) => console.log(error));
        
            if(student.id==usr_id && student.eMail == sMail && student.number == phone ){
              console.log("values are right");
              sessionStorage.setItem("userMail",sMail)
              sessionStorage.setItem("userId",usr_id)
              navigate("/change-password")

            }
            else{
              console.log("Values are not right");
            }

          }

          if(user.role =="Teacher"){
            axios.get("http://localhost:5099/api/Teacher/getTeachersByTheirId/"+usr_id)
          .then((response) => {
          console.log(response.data);
          setTeacher(response.data)
          console.log(usr_id);
          console.log(sMail);
          console.log(phone);

          
        })
        .catch((error) => console.log(error));
        
        console.log("TeacherIdddd="+teacher.teacherId);
            if(teacher.teacherId===usr_id && teacher.teacherEmail === sMail && teacher.teacherPhone === phone ){
              console.log("values are right");
              sessionStorage.setItem("userMail",sMail)
              sessionStorage.setItem("userId",usr_id)
              navigate("/change-password")

            }
            else{
              console.log("Values are not right for teacher" );
            }


          }
          
             
        };
       

  return (
    <div>
            <div class="mb-3">
            <div>
              
            <input type="text" className="form-control" name id aria-describedby="helpId" placeholder="Enter Id" onChange={(e)=>setSid(e.target.value)} />
            <input type="text" className="form-control" name id aria-describedby="helpId" placeholder="Enter mail" onChange={(e)=>setMail(e.target.value)} />
            <input type="text" className="form-control" name id aria-describedby="helpId" placeholder="Enter Phone Number" onChange={(e)=>setPhone(e.target.value)} />
            </div>
            <button onClick={chnagpassVal} type="button" className="btn btn-primary" >
            submit
            </button>

            
            </div>

            
    </div>
  )
}
