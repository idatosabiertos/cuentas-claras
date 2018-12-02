import {NgModule} from "@angular/core";
import {CommonModule} from "@angular/common";
import {MDBBootstrapModule} from "angular-bootstrap-md";
import {FooterComponent} from "./layout/footer/footer.component";
import {HeaderComponent} from "./layout/header/header.component";
import {BreadcrumbComponent} from "./layout/breadcrumb/breadcrumb.component";

@NgModule({
  declarations: [FooterComponent, HeaderComponent, BreadcrumbComponent],
  exports: [FooterComponent, HeaderComponent, BreadcrumbComponent],
  imports: [
    CommonModule,
    MDBBootstrapModule.forRoot(),
  ]
})
export class CoreModule {
}
