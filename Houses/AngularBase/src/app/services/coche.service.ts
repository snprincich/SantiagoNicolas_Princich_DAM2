import { Injectable } from '@angular/core';
import { Coche } from '../models/coche';

@Injectable({
  providedIn: 'root'
})
export class CocheService {
  cocheList: Coche[];
  readonly baseUrl = 'https://localhost:8081/api/Coche';

  constructor() {
    this.cocheList= [];

   }

   async getAllCoches(): Promise<Coche[]> {
    let headers = new Headers();
    headers.append('Authorization', 'Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IkJpbWJhX0pvZ2EiLCJyb2xlIjoiYWRtaW4iLCJuYmYiOjE3MzgyNjQ3MTYsImV4cCI6MTczODI2NTEzNiwiaWF0IjoxNzM4MjY0NzE2fQ.0aj1ScoIed0ULksXfUel8MxbVWDlYTiUQGgYl2FHPkI');
    const data = await fetch(this.baseUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }
  
async getCocheById(id: number): Promise<Coche | undefined> {
    const data = await fetch(`${this.baseUrl}/${id}`);
    return (await data.json()) ?? {};
  }
}
