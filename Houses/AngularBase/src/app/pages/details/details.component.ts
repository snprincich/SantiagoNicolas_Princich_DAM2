import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

import {FormControl, FormGroup, ReactiveFormsModule} from '@angular/forms';
import { Coche } from 'src/app/models/coche';
import { CocheService } from 'src/app/services/coche.service';

@Component({
  selector: 'app-details',
  imports: [ReactiveFormsModule],
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent {
  route: ActivatedRoute = inject(ActivatedRoute);
/*
  applyForm = new FormGroup({
    nombre: new FormControl<string>(''),
    puja: new FormControl<number>(0),
  });*/

  applyForm: FormGroup;

  coche: Coche | undefined;
  cocheService: CocheService;

  pujaActual: Number|undefined;

  constructor(cocheService: CocheService) {
    const cocheId = parseInt(this.route.snapshot.params['id'], 10);
    cocheService.getCocheById(cocheId).then((coche) => {
      this.coche = coche;
      if (coche){
        this.getPuja(coche.id)
      }
      
    });
    this.cocheService=cocheService;

    this.applyForm = new FormGroup({
      nombre: new FormControl<string>(''),
      puja: new FormControl<Number|undefined>(this.pujaActual ?? 0),
    });
  }

  async getPuja(id: number){
      this.pujaActual = await this.cocheService.getPujaActual(id) ?? 0;
  }

  async submitApplication() {

    if(this.coche && await this.cocheService.submitApplication(
      this.coche?.id,
      this.applyForm.value.nombre ?? '',
      this.applyForm.value.puja ?? 0,

    )){
      this.pujaActual = this.applyForm.value.puja;
      console.log('Puja realizada')
    }
    else{
      console.log('Error en la puja')
    }
  }

  
}
