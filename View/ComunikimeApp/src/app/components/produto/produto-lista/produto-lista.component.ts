import { Component, TemplateRef } from '@angular/core';
import { Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import { Produto } from 'src/app/models/Produto';
import { ProdutoService } from 'src/app/services/produto.service';

@Component({
  selector: 'app-produto-lista',
  templateUrl: './produto-lista.component.html',
  styleUrls: ['./produto-lista.component.scss']
})
export class ProdutoListaComponent {
  modalRef?: BsModalRef;
  public produtos: Produto[] = [];
  public produtosFiltrados: Produto[] = [];
  public produtoId = 0;

  private _listFilter: string = '';

  public get listFilter(): string {
    return this._listFilter;
  }
  public set listFilter(value: string) {
    this._listFilter = value;
    this.produtosFiltrados = this.listFilter
      ? this.filtraProdutos(this.listFilter)
      : this.produtos;
  }

  ngOnInit() {
    this.getProdutos();
  }

  constructor(
    private produtoService: ProdutoService,
    private spinner: NgxSpinnerService,
    private toastr: ToastrService,
    private modalService: BsModalService,
    private router:Router
  ) {}

  filtraProdutos(filterBy: string): Produto[] {
    filterBy = filterBy.toLowerCase();
    return this.produtos.filter(
      (produto) =>
        produto.descricao.toLowerCase().indexOf(filterBy) !== -1 ||
        produto.categoria.toLowerCase().indexOf(filterBy) !== -1
    );
  }

  public getProdutos(): void {
    this.spinner.show();
    this.produtoService.getProdutos().subscribe(
      (produtoReturn: Produto[]) => {
        this.produtos = produtoReturn;
        this.produtosFiltrados = this.produtos;
      },
      (error: any) => {
        this.toastr.error('Erro ao recuperar os dados de Produto');
        this.spinner.hide();
      },
      () => this.spinner.hide()
    );
  }

  openModal(template: TemplateRef<any>, produtoId:number, produtoDescricao:string) {
    this.produtoId = produtoId;
    this.modalRef = this.modalService.show(template, { class: 'modal-sm' });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.spinner.show();
    this.produtoService.deleteProduto(this.produtoId).subscribe(
      (result:any) => {
        if (result.message === 'Deletado'){
          this.toastr.success('Deletado com sucesso.');
          this.spinner.hide();
          this.getProdutos();
        }
      },
      (error:any) =>{
        console.error(error);
        this.toastr.error(`Erro: ${error}`);
        this.spinner.hide();
      },
      () =>{
        this.spinner.hide();
      }
    );
  }

  decline(): void {
    this.modalRef?.hide();
  }

  detalheProduto(id:number):void {
    this.router.navigate([`produto/produto-detalhe/${id}`]);
  }
}
