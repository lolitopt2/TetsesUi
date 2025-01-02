-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 02-Jan-2025 às 17:31
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
(2, 2, 2, '2024-09-11 17:07:03', '2024-12-27 17:07:03', 'Dores', 'Coxa', 'Válida');

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
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Extraindo dados da tabela `medicos`
--

INSERT INTO `medicos` (`MedicoID`, `Nome`, `Especialidade`, `Email`, `Telefone`, `Password`) VALUES
(2, 'Mrkl JR', 'Odontologia', 'fasfds', 916673784, '22222'),
(3, 'Joana', 'Onco', 'jona@adads.com', 123123, '12345'),
(4, 'dfsaasf', 'fasdasfs', 'fsadfasdf', 134324, '12345');

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
(1, 'Jorge', '2015-12-02', 'martsasdasdd', 64654, 'ddddddddd', '12345', 11111),
(2, 'Maria', '2015-12-10', 'dsfafadfadfs', 434353425, 'fasfsdafasdfa', '54321', 22222),
(3, 'dasdas', '0000-00-00', 'dadasda', 12345, '', '12345', 33333),
(4, 'Horacio', '2000-03-08', 'dasd', 132131, '', '12345', 44444),
(5, 'fdsafd', '2005-06-14', 'fsdafsdaf', 134134, '', '12345', 33333333);

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
  MODIFY `BaixaID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT de tabela `medicos`
--
ALTER TABLE `medicos`
  MODIFY `MedicoID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT de tabela `system`
--
ALTER TABLE `system`
  MODIFY `SystemID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de tabela `utentes`
--
ALTER TABLE `utentes`
  MODIFY `UtenteID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `baixas`
--
ALTER TABLE `baixas`
  ADD CONSTRAINT `baixas_ibfk_1` FOREIGN KEY (`MedicoID`) REFERENCES `medicos` (`MedicoID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `baixas_ibfk_2` FOREIGN KEY (`UtenteID`) REFERENCES `utentes` (`UtenteID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
