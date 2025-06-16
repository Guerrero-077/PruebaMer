import { Time } from "@angular/common";

export interface Citas {
    id: number;
    consultorio: number;
    fechaCita: Date;
    horaCita: Time;
    doctorName: string;
    doctorId: number;
    pacienteName: string;
    pacienteId: number;
}
export interface CitasCreate {
    id: number;
    consultorio: number;
    fechaCita: Date;
    horaCita: Time;
    doctorId: number;
    pacienteId: number;
}