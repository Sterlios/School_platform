import * as React from "react"
import { useState, useEffect } from "react";
import { useParams } from "react-router-dom";

interface Module {
    id: number;
    name: string;
    description: string;
}

interface Course {
    id: number;
    name: string;
    description: string;
    modules: Module[];
}

function CourseDetails(id) {
    
    const [course, setCourse] = useState<Course | null>(null);

    useEffect(() => {
        fetch(`https://localhost:7192/courses/${id}`)
            .then(response => response.json())
            .then(data => setCourse(data))
            .catch(error => console.error("������ �������� �����:", error));
    }, [id]);

    if (!course) {
        return <p>��������...</p>;
    }

    return (
        <div>
            <h2>{course.name}</h2>
            <p>{course.description}</p>
            <h3>������:</h3>
            {course.modules.length > 0 ? (
                <ul>
                    {course.modules.map(module => (
                        <li key={module.id}>
                            <strong>{module.name}</strong>: {module.description}
                        </li>
                    ))}
                </ul>
            ) : (
                <p>��� �������</p>
            )}
        </div>
    );
}

export default CourseDetails;
