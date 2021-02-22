export interface Teacher{
    id: number | null;
    name: string;
    birthDate:string;
}

export interface Course{
    id: number | null;
    name: string;
    teachers: number;
    students: number;
    average: string;
}

export interface Student{
    id: number | null;
    name: string;
}

export interface Subject{
    id: number | null;
    course: string;
    teacher: string;
    students: number;
    average : number;
}

export interface Enrollment{
    id: number | null;
    subject: string;
    student: string;
    score:number;
}