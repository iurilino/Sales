select
	h.DataVenda,
	h.Status,
	h.ValorVenda 'Valor total',
	i.Quantidade,
	i.ValorUnitario,
	p.Nome 'produto',
	c.Nome 'cliente',
	v.Nome 'vendedor',
	i.*
from 
	HistoricoVendas h
	left join ItemVenda i on i.HistoricoVendaId = h.Id
	left join Produtos p on p.Id = i.ProdutoId
	left join Vendedores v on v.Id = h.VendedorId
	left join Clientes c on c.Id = h.ClienteId