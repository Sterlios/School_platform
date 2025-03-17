import * as React from "react"
import { useState, useEffect } from "react";
import { CourseDetails } from "../Pages/CourseDetails";
import { useNavigate } from "react-router-dom";

interface Course {
    id: number;
    name: string;
    description: string;
}

function Courses() {
    const [courses, setCourses] = useState<Course[]>([]);
    useEffect(() => {
        fetch("https://localhost:7192/courses/")
            .then(response => response.json())
            .then(data => {
                console.log("Загруженные курсы:", data);
                setCourses(data);
            })
            .catch(error => console.error("Ошибка загрузки курсов:", error));
    }, []);

    const coursesList = courses.length > 0 ? (courses.map(course => (
        <div className='course-box' key={course.id}>
            {course.name} : {course.description}
        </div>
    ))) : (
        <p>Нет доступных курсов</p>
    );

    return (
        <div>
            <h2>Список курсов</h2>
            <div className='courses-dashboard'>
                {coursesList}
            </div>
        </div>
    );
}

export default Courses;

