import axios from 'axios'
import React,{useEffect,useState} from 'react'

export default function TeacherNotification() {
    const [notification, setNotification] = useState([])
    useEffect(() => {
     axios
     .get("http://localhost:5099/api/Notification/GetNotification")
     .then((response)=>{
        const allUserNotifications = response.data.filter(notification => notification.role !== "students");
        console.log(allUserNotifications);
        setNotification(allUserNotifications)
     })
    }, [])
  return (
    <div className="main-content position-relative max-height-vh-100 h-100 border-radius-lg">
       <table className="table table-striped text-center">
            <thead>
                <tr>
                    <th><b>Date</b></th>
                    <th><b>Message</b></th>
                </tr>
            </thead>
            <tbody>
                {
                    notification.map((item)=>{
                        return(
                            <tr>
                                <td>{item.date}</td>
                                <td>{item.message}</td>

                            </tr>
                        )
                    })
                }
            </tbody>
        </table>
    </div>
  )
}
