import {IdAndName} from "./id-and-name";
import { Specialization } from "./specialization"

//storing array of data in Country
export const TEACHERS: IdAndName[] =[
   {id:1, name :"Сидоренко К.Р."},
   {id:2, name: "Павлів О.В."},
   {id:3, name: "Білик М.А."},
   {id:4, name: "Карапуз С.М."}
];

export const SUBJECTS: IdAndName[] =[
   {id:1, name :"Архітектура програмного забезпечення"},
   {id:2, name: "Мат. аналіз"},
   {id:3, name: "Моделювання комп. систем"},
   {id:4, name: "Економічна теорія множин"}
];

export const DEPARTMENTS: IdAndName[] =[
   {id:1, name :"Програмного забезпечення"},
   {id:2, name: "Автоматизованих систем"},
   {id:3, name: "Зовнішньої економіки"},
   {id:4, name: "Маркетингу"}
];

export const INSTITUTES: IdAndName[] =[
   {id:1, name :"ІКНІ"},
   {id:2, name: "ІКНА"},
   {id:3, name: "ІНЕМ"},
   {id:4, name: "ІАРГ"}
];

export const STREAMS: IdAndName[] =[
   {id:1, name :"ПІ-1"},
   {id:2, name: "ПІ-2"},
   {id:3, name: "ПІ-3"},
   {id:4, name: "ПІ-4"}
];

export const SPECIALIZATIONS: Specialization[] =[
   {id:1, name :"Програмна інженерія", firstAcademYear: 2014, semesters: 4},
   {id:2, name: "Програмна архітектура", firstAcademYear: 2010, semesters: 8},
   {id:3, name: "Менеджиент", firstAcademYear: 2012, semesters: 6},
   {id:4, name: "Маркетинг", firstAcademYear: 2008, semesters:4}
];