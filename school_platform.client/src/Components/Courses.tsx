import * as React from "react"
import { useState, useEffect } from "react";

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
        <li key={course.id}>
            {course.name} : {course.description}
        </li>
    ))) : (
        <p>Нет доступных курсов</p>
    );

    return (
        <div>
            <h2>Список курсов</h2>
            <ul>
                {coursesList}
            </ul>
        </div>
    );
}

export default Courses;