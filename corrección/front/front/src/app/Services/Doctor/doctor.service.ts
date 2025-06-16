import { Injectable } from '@angular/core';
import { Doctor, DoctorCreate } from '../../Models/Doctor/doctor.models';
import { HttpClient } from '@angular/common/http';
import { GenericService } from '../generic/generic-service.service';

@Injectable({
  providedIn: 'root'
})
export class DoctorService extends GenericService<Doctor, DoctorCreate> {

  constructor(http: HttpClient) {
    super(http, 'doctor');
  }
}
