import { Component, ElementRef, OnInit, Renderer2, ViewChild } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ContactService } from './contact.service';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss']
})
export class ContactComponent implements OnInit {
  public contactForm: FormGroup;
  public emailStatus: string;
  public emailStatusMsg: string;

  @ViewChild('alert') alert: ElementRef;

  constructor(private _formBuilder: FormBuilder,
              private renderer: Renderer2,
              private contactService: ContactService) {
  }

  public ngOnInit() {
    this.contactForm = this._formBuilder.group({
      name: ['', Validators.required],
      email: ['', Validators.compose([Validators.required, Validators.email])],
      message: ['', Validators.required],
    });
  }

  public sendEmail() {
    if (this.contactForm.valid) {
      this.contactService.sendEmail(this.contactForm.value).subscribe(() => {
        this.emailStatus = 'success';
        this.emailStatusMsg = 'Su consulta fue enviada exitosamente.';
        setTimeout(() => {
          this.alert.nativeElement.classList.add('show');
        });
      }, () => {
        this.emailStatus = 'danger';
        this.emailStatusMsg = 'No fue posible enviar su consulta, porfavor intente nuevamente o contacte a un administrador.';
        setTimeout(() => {
          this.alert.nativeElement.classList.add('show');
        });
      });
    }
  }

  public closeAlert() {
    this.alert.nativeElement.classList.remove('show');
  }
}
