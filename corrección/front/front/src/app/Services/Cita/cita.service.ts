import { Injectable } from '@angular/core';
import { Citas, CitasCreate } from '../../Models/Cita/Citas.models';
import { HttpClient } from '@angular/common/http';
import { GenericService } from '../generic/generic-service.service';

@Injectable({
  providedIn: 'root'
})
export class CitaService extends GenericService<Citas, CitasCreate> {

  constructor(http: HttpClient) {
    super(http, 'cita');
  }
}
