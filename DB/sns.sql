-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Tempo de geração: 16-Dez-2024 às 03:02
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
  `Observacoes` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  `SystemID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  `Password` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

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
  ADD PRIMARY KEY (`MedicoID`),
  ADD KEY `SystemID` (`SystemID`);

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
  MODIFY `BaixaID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `medicos`
--
ALTER TABLE `medicos`
  MODIFY `MedicoID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `system`
--
ALTER TABLE `system`
  MODIFY `SystemID` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT de tabela `utentes`
--
ALTER TABLE `utentes`
  MODIFY `UtenteID` int(11) NOT NULL AUTO_INCREMENT;

--
-- Restrições para despejos de tabelas
--

--
-- Limitadores para a tabela `baixas`
--
ALTER TABLE `baixas`
  ADD CONSTRAINT `baixas_ibfk_1` FOREIGN KEY (`MedicoID`) REFERENCES `medicos` (`MedicoID`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `baixas_ibfk_2` FOREIGN KEY (`UtenteID`) REFERENCES `utentes` (`UtenteID`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Limitadores para a tabela `medicos`
--
ALTER TABLE `medicos`
  ADD CONSTRAINT `medicos_ibfk_1` FOREIGN KEY (`SystemID`) REFERENCES `system` (`SystemID`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
