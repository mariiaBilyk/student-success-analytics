import {Injectable} from "@angular/core";
import {TEACHERS} from "../models/teacher.data";

//@Injectable() specifies class is available to an injector for instantiation and an injector will display an error when trying to instantiate a class that is not marked as @Injectable()

@Injectable()

//CountryService exposes the getContacts() method that returns the data
export class TeacherService {
    private TeachersEndpoint = "http://localhost:51113/api/teachers"; 

   getTeachers() {
      return Promise.resolve(TEACHERS); // takes values from country.contacts typescript file
   }
}