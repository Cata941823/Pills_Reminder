import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpResponse, HttpHeaders, HttpClient } from '@angular/common/http';

export class UpdateUtilizator {
  Nume;
  Prenume;
  Parola;
}

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  constructor(private httpClient: HttpClient) { }

  getUtilizatorLogat(): Observable<HttpResponse<any>> {
    let url = "https://localhost:5001/api/Profile/InfoProfile";
    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };

    return this.httpClient.get<any>(url, options);
  }

  update(user: UpdateUtilizator): Observable<HttpResponse<any>> {
    let url = "https://localhost:5001/api/Profile/UpdateProfile";
    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };
    let payload = { "Nume": user.Nume, "Prenume": user.Prenume, "Parola": user.Parola };
    return this.httpClient.put<any>(url, payload, options);
  }

  delete() {
    let url = "https://localhost:5001/api/Profile/DeleteProfile";
    let token = localStorage.getItem("token");
    console.log(token);
    let headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': token
    });
    let options = { headers: headers };

    return this.httpClient.delete<any>(url, options);
  }

}
