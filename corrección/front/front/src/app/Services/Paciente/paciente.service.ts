import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { GenericService } from '../generic/generic-service.service';
import { Paciente, PacienteCreate } from '../../Models/Paciente/paciente.models';

@Injectable({
  providedIn: 'root'
})
export class PacienteService extends GenericService<Paciente, PacienteCreate> {

  constructor(http: HttpClient) {
    super(http, 'paciente');
  }
}
