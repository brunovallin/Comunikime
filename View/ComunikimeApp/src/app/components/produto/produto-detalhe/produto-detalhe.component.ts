import { Component, OnInit } from '@angular/core';
import {
  FormControl,
  FormBuilder,
  FormGroup,
  Validators,
} from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-produto-detalhe',
  templateUrl: './produto-detalhe.component.html',
  styleUrls: ['./produto-detalhe.component.scss'],
})
export class ProdutoDetalheComponent implements OnInit {
  produto = {} as Produto;
  form!: FormGroup;
  statusSalva = 'post';
  public produtoId = 0;

  get f(): any {
    return this.form?.controls;
  }

  constructor(private spinner:NgxSpinnerService,
    private toastr: ToastrService,
    private fb: FormBuilder,
    private router: ActivatedRoute,
    private produtoService: ProdutoService
  ) {}

  ngOnInit() {
    this.validation();
    this.carregarProduto();
  }

  numberOnly(event: any): boolean {
    const charCode = event.which ? event.which : event.keyCode;
    if (charCode > 31 && (charCode < 48 || charCode > 57) && charCode !== 46) {
      return false;
    }
    return true;
  }

  public validation(): void {
    this.form = this.fb.group({
      descricao: new FormControl('', Validators.required),
      precoUnitario: new FormControl('', Validators.required),
      quantidadeEstoque: new FormControl('', Validators.required),
      categoria: new FormControl('', Validators.required),
    });
  }

  resetForm(): void {
    this.form.reset();
  }
  public carregarProduto(): void {
    const produtoIdParam = this.router.snapshot.paramMap.get('id');

    if (produtoIdParam !== null) {
      this.spinner.show();
      this.statusSalva = 'put';
      this.produtoService.getProdutoById(+produtoIdParam).subscribe(
        (produto: Produto) => {
          this.produto = { ...produto };
          this.form.patchValue(this.produto);
        },
        (error: any) => {
          console.log(error);
          this.spinner.hide();
        },
        () => this.spinner.hide()
      );
    }
  }

  public salvarProduto(): void {
    this.spinner.show();
    if (this.form.valid) {

      if(this.statusSalva === 'post'){
        this.produto = { ... this.form.value };
        this.produtoService.postProduto(this.produto).subscribe(
          () => this.toastr.success('Produto cadastrado com sucesso.'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            //toastr
          },
          () => this.spinner.hide()
        );
      }else{
        this.produto = {id: this.produto.id, ... this.form.value };
        this.produtoService.putProduto(this.produto.id, this.produto).subscribe(
          () => this.toastr.success('Produto alterado com sucesso.'),
          (error: any) => {
            console.error(error);
            this.spinner.hide();
            this.toastr.error(`Erro ao alterar produto:${this.produto.descricao}`);
          },
          () => this.spinner.hide()
        );
      }
    }
  }
}
