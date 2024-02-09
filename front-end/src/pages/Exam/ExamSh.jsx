import axios from 'axios'
import React, {  useState } from 'react'
import { useNavigate } from 'react-router-dom'

export default function ExamSch() {
    const [eid, setEid] = useState("")
    const [ename, setEname] = useState("")
    const [etime, setTime] = useState("")
    const[cid,setCid]=useState("")
    const [edate, setEdate] = useState("")
    const [subid, setSubid] = useState("")

    //const navigate=useNavigate()

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
    

    function ExamSch(){
        let values={
            examId: eid,
            examName: ename,
            examTime: etime,
            classId: cid,
            date:edate ,
            subId: subid
        }
        axios
        .post("http://localhost:5099/api/Exam/AddExam",values)
        .then((response)=>{
            console.log(response.data);
            alert("Exam Scheduled Successfully")
        })
    }

  return (
    <div>
        <h1>Exam Schedule</h1>
        <table>
            <tr>
                <td>
                    <input type='text' placeholder='Exam Id' value={eid} onChange={(e)=>setEid(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Exam Name' value={ename} onChange={(e)=>setEname(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Exam Time' value={etime} onChange={(e)=>setTime(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Class Id' value={cid} onChange={(e)=>setCid(e.target.value)}/>
                </td>
                <td>
                    <input pattern="\d{4}-\d{2}-\d{2}" type='date' placeholder='Date' value={edate} onChange={(e)=>setEdate(e.target.value)}/>
                </td>
                <td>
                    <input type='text' placeholder='Subject Id' value={subid} onChange={(e)=>setSubid(e.target.value)}/>
                </td>
            </tr>
            <tr>
                <td>
                    <button onClick={ExamSch}>Schedule Exam</button>
                </td>
            </tr>
        </table>
    </div>
  )
}
