import { Component } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { debounceTime, finalize, map, switchMap, take } from 'rxjs';
import { AccountService } from '../account.service';

@Component({
	selector: 'app-register',
	templateUrl: './register.component.html',
	styleUrls: ['./register.component.scss']
})
export class RegisterComponent {
	errors: string[] | null = null;

	constructor(private fb: FormBuilder, private accountService: AccountService, private router: Router) { }

	complexPassword = "(?=^.{6,100}$)(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!@#$%^&amp;*()_+}{&quot;:;'?/&gt;.&lt;,])(?!.*\s).*$"

	registerForm = this.fb.group({
		name: ['', [Validators.required], [this.validateNameNotTaken()]],
		password: ['', [Validators.required, Validators.pattern(this.complexPassword)]],
	})

	onSubmit() {
		this.accountService.register(this.registerForm.value).subscribe({
			next: () => this.router.navigateByUrl('/list'),
			error: error => this.errors = error.errors
		})
	}

	validateNameNotTaken(): AsyncValidatorFn {
		return (control: AbstractControl) => {
			return control.valueChanges.pipe(
				debounceTime(1000),
				take(1),
				switchMap(() => {
					return this.accountService.checkUserExists(control.value).pipe(
						map(result => result ? { nameExists: true } : null),
						finalize(() => control.markAsTouched())
					)
				})
			)

		}
	}
}
