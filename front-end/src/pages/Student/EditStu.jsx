import axios from 'axios'
import React, { useEffect, useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function EditStudent() {
    const [sid, setSid] = useState("")
    const [sfname, setSfname] = useState("")
    const [slname, setSlname] = useState("")
    const [semail, setSemail] = useState("")
    const [snumber, setSnumber] = useState("")
    const [sdob, setSdob] = useState("")
    const [sgender, setSgender] = useState("")
    const [sclass, setSclass] = useState("")
    const [ssection, setSsection] = useState("")
    const navigate=useNavigate()

    // useEffect(() => {
    //     if (sessionStorage.getItem("token") != null) {
    //         console.log(sessionStorage.getItem("token"));
    //         const header = {
    //           Authorization: `Bearer ${sessionStorage.getItem("token")}`,
    //         };
    //     }
    //     else{
    //         navigate('/login')
    //     }
    // }, [])
    

    function Update(){
        // if (sessionStorage.getItem("token") != null) {
        //     console.log(sessionStorage.getItem("token"));
        //     const header = {
        //       Authorization: `Bearer ${sessionStorage.getItem("token")}`,
        //     };
            let values={
                id:sid,
                fName:sfname,
                lName:slname,
                eMail:semail,
                number:snumber,
                dob:sdob,
                gender:sgender,
                clss:sclass,
                section:ssection,
            }
            axios
            .put("http://localhost:5099/api/Student/Edit_Student",values)
            .then((response)=>{
                console.log(response.data);
                alert("Student details updated Successfully")

            })
            .catch((err)=>console.log(err))
        };
        // else{
        //     navigate('/login')
        // }
        
    

  return (
    <div>
        <h1>Update Student</h1>
        <table>
            <tr>
            <td>
                    <input type='text' placeholder='Student Id' value={sid} onChange={(e)=>setSid(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Student First Name' value={sfname} onChange={(e)=>setSfname(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Student Last Name' value={slname} onChange={(e)=>setSlname(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Email' value={semail} onChange={(e)=>setSemail(e.target.value)}/>
                </td>
                <td>
                    <input type='Mobile' placeholder='Mobile' value={snumber} onChange={(e)=>setSnumber(e.target.value)}/>
                </td>
                <td>
                    <input type='date' placeholder='DOB ' value={sdob} onChange={(e)=>setSdob(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Gender' value={sgender} onChange={(e)=>setSgender(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Standard' value={sclass} onChange={(e)=>setSclass(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Section' value={ssection} onChange={(e)=>setSsection(e.target.value)}/>
                </td>

            </tr>
            <tr>
                <td>
                    <button onClick={Update}>Update Student</button>
                </td>
            </tr>
        </table>
    </div>
  )

  }