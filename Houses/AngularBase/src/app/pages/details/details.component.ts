import { Component, inject } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { HousingLocation } from 'src/app/models/housinglocation';
import { HousingService } from 'src/app/services/housing.service';
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

  applyForm = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
  });
  
  /*housingLocation: HousingLocation | undefined;
  housingService: HousingService;*/

  coche: Coche | undefined;
  cocheService: CocheService;

  /*
  constructor(housingService: HousingService) {
      const housingLocationId = parseInt(this.route.snapshot.params['id'], 1);
      housingService.getHousingLocationById(housingLocationId).then((housingLocation) => {
        this.housingLocation = housingLocation;
      });
      this.housingService=housingService;
  }*/

  constructor(cocheService: CocheService) {
      const cocheId = parseInt(this.route.snapshot.params['id'], 10);
      cocheService.getCocheById(cocheId).then((coche) => {
        this.coche = coche;
      });
      this.cocheService=cocheService;
  }

  /*
  submitApplication() {
    this.housingService.submitApplication(
      this.applyForm.value.firstName ?? '',
      this.applyForm.value.lastName ?? '',
      this.applyForm.value.email ?? '',
    );
  }*/
}
