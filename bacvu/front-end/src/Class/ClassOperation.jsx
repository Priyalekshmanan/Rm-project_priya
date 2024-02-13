import axios from 'axios';
import React, { useState } from 'react'

export default function ClassOperation() {

 const [classs, getcls] = useState([])

        const GetAllClass=() =>{
            axios
            .get("http://localhost:5099/api/ClassM/GetAllClass")
            .then((response)=>{
                console.log(response.data);
                getcls(response.data);
            })
            .catch((error)=>{
                console.log(error);
            });
        
       
            
        }
        // const Delete=(cid)=>{
                 
        // axios
        // .delete("http://localhost:5099/api/ClassM/DeleteClass/"+cid)
        // .then((response)=>{
        //     console.log(response.data);
        //     alert("Deleted Successfully")
        //     // setCid(response.data)
        // })
        // .catch((err)=>{
        //     console.log("error in fetching user",err);
        //     alert("error in fetching");
        // })
        // }
     
          
       
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
        <table className='table table-stripped'>
            <thead>
                <tr>
                    <th>ClassId</th>
                    <th>ClassName</th>
                    <th>StreamName</th>
                    <th>TeacherId</th>
                    {/* <th>Teacher</th> */}

                </tr>
            </thead>
            <tbody>
               
                  {
                    classs.map((item,index)=>{
                        return(
                            <tr key={index}>
                                <td>{item.classId}</td>
                                <td>{item.semName}</td>
                                <td>{item.streamName}</td>
                                <td>{item.teacherid}</td>
                                {/* <td>{item.teacher}</td> */}
                                {/* <td>
                                    <button onClick={()=>Delete(item.classId)}type="button">Delete</button>
                                </td> */}
                                
                            </tr>

                        )
                    })
                  }
            </tbody>
        </table>
        <button onClick={GetAllClass } type="button"className="btn btn-outline-primary">View Students</button>
    </div>
  )
}
