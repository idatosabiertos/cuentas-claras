import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MDBBootstrapModule} from "angular-bootstrap-md";
import {FooterComponent} from "./layout/footer/footer.component";

@NgModule({
  declarations: [FooterComponent],
  exports: [FooterComponent],
  imports: [
    CommonModule,
    MDBBootstrapModule.forRoot(),
  ]
})
export class CoreModule {
}
