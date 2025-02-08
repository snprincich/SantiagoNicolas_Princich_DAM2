import { Injectable } from '@angular/core';
import { Coche } from '../models/coche';
import { Puja } from '../models/puja';

@Injectable({
  providedIn: 'root'
})
export class CocheService {
  cocheList: Coche[];

  readonly baseUrl = 'https://localhost:8081/api/Coche';
  readonly pujaUrl = 'https://localhost:8081/api/Puja';


  constructor() {
    this.cocheList= [];

   }

   async getAllCoches(): Promise<Coche[]> {
    let headers = new Headers();
    headers.append('Authorization', '');
    const data = await fetch(this.baseUrl,{method:'GET',
      headers: headers,
     });
    return (await data.json()) ?? [];
  }

async getCocheById(id: number): Promise<Coche | undefined> {
    const data = await fetch(`${this.baseUrl}/${id}`);
    return (await data.json()) ?? {};
  }

  async postPuja(puja:Puja): Promise<Puja> {
    let headers = new Headers();
    headers.append('Authorization', '');
    headers.append('Content-Type', 'application/json');
    const data = await fetch(this.pujaUrl,{method:'POST',
      headers: headers,
      body: JSON.stringify(puja),
     });
    return (await data.json()) ?? [];
  }

  async getPujaActual(id: number): Promise<number> {
    let headers = new Headers();
    headers.append('Authorization', '');
    const data = await fetch(this.pujaUrl,{method:'GET',
      headers: headers,
     });
    var pujaList: Puja[] = (await data.json()) ?? [];
    
    pujaList = pujaList.filter((puja: Puja) => puja.id_coche === id);
    
    let pujaMaxima =  (await this.getCocheById(id))?.pujaInicial ?? 0;

    for (let puja of pujaList) {
      pujaMaxima = pujaMaxima>= puja.pujaActual? pujaMaxima : puja.pujaActual;
    }
  
  return pujaMaxima;
}

  async submitApplication(id: number, nombre: string, puja: number): Promise<boolean> {
    
    if (await this.getPujaActual(id) < puja){
    const nuevaPuja: Puja = {
      id: 0,
      id_coche: id,
      nombre: nombre,
      pujaActual: puja
    }

    var resultado = await this.postPuja(nuevaPuja);
    
    if (resultado &&  
        'id' in resultado &&
        'id_coche' in resultado &&
        'nombre' in resultado &&
        'pujaActual' in resultado
    ){
      return true;
    }
  }
  return false;
}
}
