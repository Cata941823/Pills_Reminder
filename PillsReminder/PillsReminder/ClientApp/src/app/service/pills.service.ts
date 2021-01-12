import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpHeaders, HttpRequest } from '@angular/common/http';
import { Observable } from 'rxjs';

export class DozajAfisare {
  Cantitate;
  Data;
  Ora;
  Medicament;
  Luata;
}


export class Pastila {
  Id;
  Denumire;
}

export class Doza {
  Cantitate_pastila;
  DataInceput;
  NumarZile;
  Ora;
  IdPastila;
}

@Injectable({
  providedIn: 'root'
})
export class PillsService {

  lista_tuturor_pastilelor: Array<Pastila> = new Array<Pastila>();

  constructor(private httpClient: HttpClient) { }

  getAllPastile(): Observable<HttpResponse<any>> {
    let url = "https://localhost:5001/api/Pills/GetListaPastile";
    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };

    return this.httpClient.get<any>(url, options);
  }

  createDoza(doza): Observable<HttpRequest<any>> {
    let url = "https://localhost:5001/api/Pills/CreateDoza";

    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };

    let payload = { data: doza };

    console.log(doza);
    return this.httpClient.post<any>(url, payload.data, options, );
  }

  getAllMedicamentatii(): Observable<HttpResponse<any>> {
    let url = "https://localhost:5001/api/Pills/GetListaDoze";
    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };

    return this.httpClient.get<any>(url, options);
  }

}
