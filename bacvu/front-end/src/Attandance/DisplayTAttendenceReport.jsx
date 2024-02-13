import axios from 'axios'
import React, { useState } from 'react'

export default function DisplayTAttendenceReport() {
    const[tstartdate,setTstartdate]=useState("")
    const[tenddate,setTenddate]=useState("")
    const[disp,setDisp]=useState([])
    // const [startdateError, setStartDateError] = useState('');
    // const [enddateError, setEndDateError] = useState('');

    const GenerateReport=(e)=>{
         e.preventDefault(); // Prevent default form submission behavior

        // Reset errors
        //setStartDateError('');
        //setEndDateError('');

        // Validation
        // let isValid = true;
        // if (!startdateError) {
        //      setStartDateError('Startdate is required');
        //     isValid = false;
        // }
        // if (!enddateError) {
        //    setEndDateError('EndDate is required');
        //     isValid = false;
        // }
    
        // if(isValid){
        axios.
        get("http://localhost:5099/api/DisplayAttendance/AllTeacherAttendence/"+tstartdate+"&"+tenddate)
        .then((response)=>{
            console.log(response.data);
            setDisp(response.data);
        })
        .catch((error)=>{
            console.log("Error in generation report",error);
            alert("error in generating report");
        });
    //}
        
} 
  return (
    <div>
     <form className="d-flex justify-content-end">
                    <div className="mb-3">
                        <input
                            onChange={(e) => setTstartdate(e.target.value)}
                            type="text"
                             //className={`form-control ${startdateError && 'is-invalid'}`}
                            placeholder="Enter start date"
                        />
                         {/* {startdateError && <div className="invalid-feedback">{startdateError}</div>}  */}
                    </div>
                    <div className="mb-3">
                        <input
                            onChange={(e) => setTenddate(e.target.value)}
                            type="text"
                            // className={`form-control ${enddateError && 'is-invalid'}`}
                            placeholder="Enter end Date"
                        />
                        {/* {enddateError && <div className="invalid-feedback">{enddateError}</div>}  */}
                    </div>
                    <button onClick={GenerateReport} className="btn btn-primary" type="submit">
                      Generate Report
                    </button>
                </form>
                <table className='table table-stripped'>
            <thead>
                <tr>
                 
                    <th>teacherId</th>
                    <th>presentDays</th>
                    <th>absentDays</th>
                    <th>totalWorking</th>  
                </tr>
            </thead>
            <tbody>
               
                 {
                    disp.map((item,index)=>{
                        return(
                            <tr key={index}>
                                <td>{item.teacherId}</td>
                                <td>{item.presentDays}</td>
                                <td>{item.absentDays}</td>
                                <td>{item.totalWorking}</td>
                                

                            </tr>
                        )
                    })
                 }
            </tbody>
        </table>

    </div>
  )
}

/* import axios from 'axios'
import React, { useEffect, useState } from 'react'
// import { useNavigate } from 'react-router-dom'

export default function DisplayTeacherAttendace() {
    
        const [tstartdate, setTstartdate] = useState("")
        const [tenddate, setTenddate] = useState(0)
        const[dis,setDis]=useState([])
        // const navigate=useNavigate()

        function DisplayAlltea(){
            axios
            .get("http://localhost:5099/api/DisplayAttendance/AllTeacherAttendence"+tstartdate+"/"+tenddate)
            .then((response)=>{
            console.log(response.data);
            setDis(response.data)
        })
        .catch((e)=>{
            console.log(e)
        })
           
       }
            
        
    
  return (
    <div>DisplayStuAttbysdNed
    <table>
        <tr>
        <td>
            <input type='text' placeholder='Start Date' value={tstartdate} onChange={(e)=>setTstartdate(e.target.value)}/>
            <input type='text' placeholder='End Date' value={tenddate} onChange={(e)=>setTenddate(e.target.value)}/>
        </td>
        </tr>
        <tr>
            <td>
                <button onClick={DisplayAlltea}>Click</button>
            </td>
        </tr>
    </table>
    <table className='table table-stripped'>
            <thead>
                <tr>
                 
                    <th>teacherId</th>
                    <th>presentDays</th>
                    <th>absentDays</th>
                    <th>totalWorking</th>
                  

                
                </tr>
            </thead>
            <tbody>
               
                 {
                    dis.map((item)=>{
                        return(
                            <tr key={item.teacherId}>
                                <td>{item.teacherId}</td>
                                <td>{item.presentDays}</td>
                                <td>{item.absentDays}</td>
                                <td>{item.totalWorking}</td>
                                

                            </tr>
                        )
                    })
                 }
            </tbody>
        </table>
    </div>
  )
  } */