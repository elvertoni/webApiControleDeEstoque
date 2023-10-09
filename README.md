<h1>Resumo do Projeto: Sistema de Controle de Estoque</h1>

<h2>Objetivo do Projeto:</h2>
O objetivo deste projeto é desenvolver um sistema de gestão de estoque eficaz, com a finalidade de melhorar a administração de produtos. O foco central é criar uma ferramenta que ofereça uma visão imediata e completa das quantidades de produtos disponíveis no inventário da empresa. Este sistema visa reduzir ou eliminar perdas decorrentes de problemas no controle de estoque, evitando tanto a falta de produtos quanto o vencimento de produtos.
O projeto busca otimizar significativamente os processos de solicitação e reposição de itens em estoque, visando aumentar a eficiência operacional e minimizar potenciais interrupções nas atividades comerciais. Portanto, o principal propósito deste projeto é fortalecer a capacidade de tomada de decisão e atender às demandas do “mercado” de forma precisa, eficiente e ágil, impulsionando à gestão de estoque e, por consequência, melhorando a competitividade da organização.

<h2>Tecnologias Utilizadas:</h2>
Este projeto de controle de estoque será desenvolvido como uma aplicação web, empregando as tecnologias .NET 6.0 e MySQL. Essas tecnologias serão integradas para criar uma solução eficiente de gerenciamento de estoque.

<h2>Descrição do Sistema:</h2>
A aplicação web resultante permitirá que os colaboradores da empresa, com base no do nível de autorização, realizem uma variedade de operações relacionadas ao estoque. Isso incluirá a capacidade de adicionar novos produtos, atualizar informações sobre produtos existentes, verificar o estado atual do estoque, gerar relatórios sobre a disponibilidade de itens e também conseguir verificar os itens que estão próximos da sua data de validade.

<h2>Principais Funcionalidades:</h2>
Cadastro de produtos: Funcionários autorizados poderão adicionar informações detalhadas sobre novos produtos, incluindo nome, descrição, preço, quantidade inicial, etc.
Atualização de estoque: O sistema permitirá a atualização contínua do estoque à medida que os produtos forem comprados, vendidos ou recebidos.
Busca de itens: Serão disponibilizados relatórios detalhados sobre o desempenho do estoque, incluindo vendas, entradas, saídas e níveis de estoque mínimo e máximo.
Notificações de estoque baixo: Os responsáveis pelo estoque receberão notificações automáticas quando o nível de estoque de um produto atingir um limite mínimo definido.
Autenticação e níveis de acesso: O sistema terá diferentes níveis de acesso, permitindo que funcionários com diferentes responsabilidades acessem apenas as funcionalidades relevantes.
Histórico de transações: Um registro completo de todas as transações de estoque será mantido para fins de auditoria e rastreamento.

<h2>Benefícios Esperados:</h2>
<p>•	Redução de custos devido a menos desperdício de produtos obsoletos.</p>
<p>•	Maior eficiência operacional no gerenciamento de estoque.</p>
<p>•	Melhor controle sobre a disponibilidade de produtos para atender às demandas dos clientes.</p>
<p>•	Tomada de decisões baseada em dados, com relatórios mais precisos.</p>
<p>•	Melhoria na experiência do cliente devido à disponibilidade consistente de produtos.</p>
 
<img src="diagrama.jpg">

<h2>Funcionalidades Descritivo Resumido</h2>
<h3>Estoque:</h3>
<p>• AtualizarEstoque(): Atualiza as informações de estoque de produtos.</p>
<p>•	VerificarNívelMínimo(): Verifica se o estoque está abaixo do nível mínimo.</p>
<p>•	VerificarNívelMáximo(): Verifica se o estoque está acima do nível máximo.</p>
<h3>Produto:</h3>
<p>•	AdicionarProduto(): Adiciona um novo produto ao sistema.</p>
<p>•	RemoverProduto(): Remove um produto do sistema.</p>
<p>•	AtualizarPreço(): Atualiza o preço de um produto.</p>
<p>•	AtualizarQuantidade(): Atualiza a quantidade de um produto em estoque.</p>
<p>•	getQuantidadeEstoque(): Obtém a quantidade em estoque de um produto.</p>
<p>•	setQuantidadeEstoque(): Define a quantidade em estoque de um produto.</p>
<h3>Fornecedor:</h3>
<p>•	AdicionarFornecedor(): Adiciona um novo fornecedor ao sistema.</p>
<p>•	RemoverFornecedor(): Remove um fornecedor do sistema.</p>
<p>•	AtualizarFornecedor(): Atualiza informações de um fornecedor.</p>
<p>•	VisualizarFornecedor(): Exibe informações de um fornecedor.</p>
<p>•	getNome(): Obtém o nome do fornecedor.</p>
<p>•	setNome(): Define o nome do fornecedor.</p>
<p>•	getEndereço(): Obtém o endereço do fornecedor.</p>
<p>•	setEndereço(): Define o endereço do fornecedor.</p>
<h3>Categoria:</h3>
<p>•	AdicionarCategoria(): Adiciona uma nova categoria de produto ao sistema.</p>
<p>•	RemoverCategoria(): Remove uma categoria de produto do sistema.</p>
<p>•	VisualizarCategoria(): Exibe informações sobre uma categoria.</p>
<p>•	AtualizarCategoria(): Atualiza informações de uma categoria.</p>
<p>•	getNome(): Obtém o nome da categoria.</p>
<p>•	setNome(): Define o nome da categoria.</p>
<p>•	getDescrição(): Obtém a descrição da categoria.</p>
<p>•	setDescrição(): Define a descrição da categoria.</p>
<h3>Funcionário:</h3>
<p>•	RealizarLogin(): Permite que um funcionário faça login no sistema.</p>
<p>•	iFornecedor(): Interface para operações relacionadas a fornecedores.</p>
<p>•	ICategoria(): Interface para operações relacionadas a categorias.</p>
<p>•	IProduto(): Interface para operações relacionadas a produtos.</p>

<h2>Conclusão:</h2>
Este projeto visa aprimorar significativamente a gestão de estoque da empresa, tornando-a mais eficiente, precisa e ágil. A implementação bem-sucedida deste sistema trará benefícios tanto internos quanto externos, resultando em economias de custos e aumento da satisfação do cliente.
