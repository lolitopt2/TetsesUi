-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 18-Fev-2025 às 05:04
-- Versão do servidor: 10.4.32-MariaDB
-- versão do PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Banco de dados: `sns`
--

-- --------------------------------------------------------

--
-- Estrutura da tabela `baixas`
--

CREATE TABLE `baixas` (
  `BaixaID` int(11) NOT NULL,
  `MedicoID` int(11) NOT NULL,
  `UtenteID` int(11) NOT NULL,
  `DataInicio` datetime NOT NULL,
  `DataFim` datetime NOT NULL,
  `Motivo` varchar(100) DEFAULT NULL,
  `Observacoes` text NOT NULL,
  `estado` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `baixas`
--

INSERT INTO `baixas` (`BaixaID`, `MedicoID`, `UtenteID`, `DataInicio`, `DataFim`, `Motivo`, `Observacoes`, `estado`) VALUES
(2, 2, 2, '2024-09-11 17:07:03', '2024-12-27 17:07:03', 'Dor de costas', 'Dor na região lombar das costas', 'Inválida'),
(3, 5, 6, '2025-01-05 00:52:58', '2025-03-01 00:52:58', 'Dor de garganta', 'Possível infeção', 'Válida'),
(7, 5, 1, '2025-01-01 14:58:30', '2025-01-07 14:58:30', 'Lesão no pé', 'Ficar em repouso total até recuperação parcial.', 'Inválida'),
(8, 5, 3, '2025-01-01 15:05:19', '2025-01-22 15:05:19', 'Dor de cabeça', 'Tomar Benuron durante duração da baixa.', 'Inválida'),
(9, 5, 5, '2025-01-28 12:43:52', '2025-02-28 12:43:52', 'Fractura no Pé', 'O utente não consegue mobilizar-se e por isso deverá ficar em repouso até demonstrar melhorias significativas.', 'Válida'),
(11, 5, 5, '2025-01-01 16:15:59', '2028-01-01 16:15:59', 'Dor no peito.', 'Ficar em repouso total durante a duração da baixa.', 'Válida'),
(12, 6, 10, '2025-01-01 16:15:59', '2025-02-05 16:15:59', 'Visão turva.', 'Ficar em repouso total durante a duração da baixa.', 'Inválida'),
(13, 2, 7, '2025-01-01 16:15:59', '2030-01-01 16:15:59', 'Gota.', 'Ficar em repouso total durante a duração da baixa.', 'Válida'),
(14, 6, 2, '2025-01-28 17:15:54', '2025-05-01 16:15:59', 'Lesão no olho esquerdo.', 'Ficar em repouso total durante a duração da baixa.', 'Válida'),
(15, 7, 4, '2023-01-04 16:15:59', '2025-01-11 16:15:59', 'Incapacidade geral de movimentação.', 'Ficar em repouso total durante a duração da baixa.', 'Inválida');

-- --------------------------------------------------------

--
-- Estrutura da tabela `medicos`
--

CREATE TABLE `medicos` (
  `MedicoID` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Especialidade` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Telefone` int(11) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `CCnum` int(8) NOT NULL,
  `Instituicao` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `medicos`
--

INSERT INTO `medicos` (`MedicoID`, `Nome`, `Especialidade`, `Email`, `Telefone`, `Password`, `CCnum`, `Instituicao`) VALUES
(1, 'Gonçalo Reis', 'Pneumologia', 'goncaloreis@gmail.com', 963843968, '11111', 21551577, 'Hospital Dona Estefania'),
(2, 'Rogério Cena', 'Reumatologia', 'rogeriocena@gmail.com', 916673784, '22222', 21264204, 'Grupo José de Mello Saúde'),
(3, 'Joana Matias', 'Neurologia', 'joanamatias95@gmail.com', 964442859, '12345', 14717342, 'Hospital da Luz'),
(4, 'Verónica Sintra', 'Anestesiologia', 'veronicasintra@gmail.com', 962693964, '12345', 14006364, 'Hospital Dona Estefania'),
(5, 'Marco Matias', 'Cardiologia', 'marcomatias@gmail.com', 987456123, '54321', 12345678, 'Hospital dos Lusíadas'),
(6, 'Filipe Prates', 'Oftalmologia', 'filipeprates@gmail.com', 964371816, '12345', 18877505, 'Clínica Central do Bonfim'),
(7, 'Olivia Tabanez', 'Estomatologia', 'oliviatabanez@gmail.com', 965324426, '12345', 23230248, 'Hospital da Luz'),
(8, 'Diogo Salvado', 'Anestesiologia', 'diogosalvado@gmail.com', 914359022, '12345', 14367890, 'Hospital da Luz'),
(9, 'Manuel Baião', 'Cardiologia', 'manuelbaiao@gmail.com', 933561406, '12345', 15310642, 'Clínica Central do Bonfim'),
(10, 'Luciana Vidigal', 'Psiquiatria', 'lucianavidigal@gmail.com', 935250794, '12345', 21750159, 'Hospital de Braga');

-- --------------------------------------------------------

--
-- Estrutura da tabela `system`
--

CREATE TABLE `system` (
  `SystemID` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `system`
--

INSERT INTO `system` (`SystemID`, `Nome`, `Email`, `Password`) VALUES
(1, 'admin', 'admin@admin.com', 'admin');

-- --------------------------------------------------------

--
-- Estrutura da tabela `utentes`
--

CREATE TABLE `utentes` (
  `UtenteID` int(11) NOT NULL,
  `Nome` varchar(100) NOT NULL,
  `DataNasc` date NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Telefone` int(11) NOT NULL,
  `Morada` varchar(100) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `ccNum` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `utentes`
--

INSERT INTO `utentes` (`UtenteID`, `Nome`, `DataNasc`, `Email`, `Telefone`, `Morada`, `Password`, `ccNum`) VALUES
(1, 'Jorge Fucile', '2015-12-02', 'jorgefucile@gmail.com', 969124587, 'Avenida das avenidas, 8 3D', '12345', 147044554),
(2, 'Maria Santos', '2015-12-10', 'mariasantos1987@hotmail.com', 963987741, 'Rua das ouras 8D', '54321', 14754528),
(3, 'Rui Pires', '1994-03-09', 'ruipires@hotmail.com', 912475548, 'Avenida Boaventura 6E', '12345', 15886874),
(4, 'Horácio Simões', '2000-03-08', 'horacio@hotmail.com', 910186122, 'Avenida Cesar Sintra 14E', '12345', 147485907),
(5, 'Vera Lisboa', '2005-06-14', 'veralisboa@iol.com', 912316903, 'Praça das Avenidas 73E', '12345', 147734470),
(6, 'Francisco Moura', '1970-06-16', 'franciscomoura@gmail.com', 913546852, 'Toca do Esquilo - 7 , 3ºD', '14725', 55555),
(7, 'Pedro Tulipa', '1965-07-14', 'pedrotulipa@hotmail.com', 934849539, 'Rua do Arco 81E', '12345', 148240104),
(8, 'Mariana Tavares', '1994-08-03', 'marianat@gmail.com', 918383895, 'Rua Bilhar de Sesimbra 99F', '12345', 148100488),
(9, 'Miriam Portugal', '1975-04-12', 'mportugal@hotmail.com', 914108055, 'Rua das Flores 23F', '12345', 147149772),
(10, 'Martim Noite', '2000-10-01', 'martimnoitetoda@hotmail.com', 910777477, 'Rua das Nuvens 167F', '12345', 178520445);

--
-- Índices para tabelas despejadas
--

--
-- Índices para tabela `baixas`
--
ALTER TABLE `baixas`
  ADD PRIMARY KEY (`BaixaID`),
  ADD KEY `UtenteID` (`UtenteID`),
  ADD KEY `MedicoID` (`MedicoID`);

--
-- Índices para tabela `medicos`
--
ALTER TABLE `medicos`
  ADD PRIMARY KEY (`MedicoID`);

--
-- Índices para tabela `system`
--
ALTER TABLE `system`
  ADD PRIMARY KEY (`SystemID`);

--
-- Índices para tabela `utentes`
--
ALTER TABLE `utentes`
  ADD PRIMARY KEY (`UtenteID`);

--
-- AUTO_INCREMENT de tabelas despejadas
--

--
-- AUTO_INCREMENT de tabela `baixas`
--
ALTER TABLE `baixas`
  MODIFY `BaixaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- AUTO_INCREMENT de tabela `medicos`
--
ALTER TABLE `medicos`
  MODIFY `MedicoID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT de tabela `system`
--
ALTER TABLE `system`
  MODIFY `SystemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `utentes`
--
ALTER TABLE `utentes`
  MODIFY `UtenteID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `baixas`
--
ALTER TABLE `baixas`
  ADD CONSTRAINT `baixas_ibfk_1` FOREIGN KEY (`MedicoID`) REFERENCES `medicos` (`MedicoID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `baixas_ibfk_2` FOREIGN KEY (`UtenteID`) REFERENCES `utentes` (`UtenteID`) ON DELETE CASCADE ON UPDATE CASCADE;

DELIMITER $$
--
-- Eventos
--
CREATE DEFINER=`root`@`localhost` EVENT `AtualizarEstadoBaixas` ON SCHEDULE EVERY 1 DAY STARTS '2025-02-18 03:58:46' ON COMPLETION NOT PRESERVE ENABLE DO UPDATE baixas
SET estado = 'Inválida'
WHERE DataFim < NOW() AND estado = 'Válida'$$

DELIMITER ;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
