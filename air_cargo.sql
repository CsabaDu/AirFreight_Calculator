-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2021. Feb 28. 13:11
-- Kiszolgáló verziója: 10.4.17-MariaDB
-- PHP verzió: 8.0.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `air_cargo`
--

DELIMITER $$
--
-- Eljárások
--
CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Clear_PackingList` ()  BEGIN
	TRUNCATE TABLE packing_list;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Count_PackingList` ()  BEGIN
	SELECT
		COUNT(*) AS item_count,
        SUM(is_dgr) AS dgr_count,
		SUM(weight * pieces) AS ci_weight,
		SUM(length * width * height * pieces / 1000000) as ci_volume
	FROM packing_list;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Download_AreaCodes` ()  BEGIN
    SELECT area_code 
    FROM air_destinations.areas
    WHERE area_code <> 'WW'
    ORDER BY tc_code;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Download_CountryCodes` ()  BEGIN
	SELECT country_code
    FROM air_destinations.countries
    WHERE country_code <> 'WW'
    ORDER BY country_code ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Download_PackingList` ()  BEGIN
	SELECT length, width, height, weight, pieces, is_dgr 
    FROM packing_list;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Download_RegionCodes` ()  BEGIN
	SELECT region_code
    FROM air_destinations.regions
    WHERE region_code <> 'WW'
    ORDER BY region_code ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Get_ZoneCodes` (IN `apc` CHAR(3))  BEGIN
	SELECT
        airports.country_code,
        countries.region_code,
        regions.area_code
    FROM air_destinations.airports
    LEFT JOIN air_destinations.countries
    	ON airports.country_code = countries.country_code
    LEFT JOIN air_destinations.regions
    	ON countries.region_code = regions.region_code
    WHERE airport_code = apc;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_AccSurcharges` (IN `acc` CHAR(2), IN `ht` CHAR(2))  BEGIN
    SELECT 
        acc_schg_rates.zone_code,
        acc_schg_rates.schg_code,
        acc_schg_rates.rate_code,
        acc_schg_rates.rate_amount,
        acc_schg_rates.rate_unit,
        acc_schg_rates.rate_mmt
    FROM air_freight.acc_schg_rates
    WHERE acc_schg_rates.acc_code = acc
    	AND acc_schg_rates.handling_code = ht;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_AirCarrier_LD_Rates` (IN `apc` CHAR(3), IN `ht` CHAR(2), IN `chw` DOUBLE)  BEGIN
	SELECT
		r_MIN,
		r_N * chw AS r_0,
        CASE
        	WHEN chw < 45 THEN r_45kg * 45
            WHEN chw >= 45 THEN r_45kg * chw
        END AS r_45,
        CASE
        	WHEN chw < 100 THEN r_100kg * 100
            WHEN chw >= 100 THEN r_100kg * chw
        END AS r_100,
        CASE
        	WHEN chw < 250 THEN r_250kg * 250
            WHEN chw >= 250 THEN r_250kg * chw
        END AS r_250,
        CASE
        	WHEN chw < 300 THEN r_300kg * 300
            WHEN chw >= 300 THEN r_300kg * chw
        END AS r_300,
        CASE
        	WHEN chw < 500 THEN r_500kg * 500
            WHEN chw >= 500 THEN r_500kg * chw
        END AS r_500,
        CASE
        	WHEN chw < 1000 THEN r_1000kg * 1000
            WHEN chw >= 1000 THEN r_1000kg * chw
        END AS r_1000,
        curr_code,
        acc_rates.acc_code,
        (@idx := @idx + 1) AS idx
    FROM air_freight.acc_rates
    LEFT JOIN air_freight.acc_products 
    	ON acc_rates.acc_code = acc_products.acc_code
    		AND acc_rates.product_name = acc_products.product_name
    LEFT JOIN air_freight.air_carriers
    	ON acc_products.acc_code = air_carriers.acc_code
    CROSS JOIN (SELECT @idx := 0) AS dummy
    WHERE acc_rates.airport_code = apc
    	AND acc_rates.ac_type <> 'NB'
    	AND acc_products.handling_code = ht;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_AirCarrier_MD_Rates` (IN `apc` CHAR(3), IN `ht` CHAR(2), IN `chw` DOUBLE)  BEGIN
	SELECT
		r_MIN,
		r_N * chw AS r_0,
        CASE
        	WHEN chw < 45 THEN r_45kg * 45
            WHEN chw >= 45 THEN r_45kg * chw
        END AS r_45,
        CASE
        	WHEN chw < 100 THEN r_100kg * 100
            WHEN chw >= 100 THEN r_100kg * chw
        END AS r_100,
        CASE
        	WHEN chw < 250 THEN r_250kg * 250
            WHEN chw >= 250 THEN r_250kg * chw
        END AS r_250,
        CASE
        	WHEN chw < 300 THEN r_300kg * 300
            WHEN chw >= 300 THEN r_300kg * chw
        END AS r_300,
        CASE
        	WHEN chw < 500 THEN r_500kg * 500
            WHEN chw >= 500 THEN r_500kg * chw
        END AS r_500,
        CASE
        	WHEN chw < 1000 THEN r_1000kg * 1000
            WHEN chw >= 1000 THEN r_1000kg * chw
        END AS r_1000,
        curr_code,
        acc_rates.acc_code,
        (@idx := @idx + 1) AS idx
    FROM air_freight.acc_rates
    LEFT JOIN air_freight.acc_products 
    	ON acc_rates.acc_code = acc_products.acc_code
    		AND acc_rates.product_name = acc_products.product_name
    LEFT JOIN air_freight.air_carriers
    	ON acc_products.acc_code = air_carriers.acc_code
    CROSS JOIN (SELECT @idx := 0) AS dummy
    WHERE acc_rates.airport_code = apc
    	AND acc_rates.ac_type = 'MD'
    	AND acc_products.handling_code = ht;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_AirCarrier_NB_Rates` (IN `apc` CHAR(3), IN `ht` CHAR(2), IN `chw` DOUBLE)  BEGIN
	SELECT
		r_MIN,
		r_N * chw AS r_0,
        CASE
        	WHEN chw < 45 THEN r_45kg * 45
            WHEN chw >= 45 THEN r_45kg * chw
        END AS r_45,
        CASE
        	WHEN chw < 100 THEN r_100kg * 100
            WHEN chw >= 100 THEN r_100kg * chw
        END AS r_100,
        CASE
        	WHEN chw < 250 THEN r_250kg * 250
            WHEN chw >= 250 THEN r_250kg * chw
        END AS r_250,
        CASE
        	WHEN chw < 300 THEN r_300kg * 300
            WHEN chw >= 300 THEN r_300kg * chw
        END AS r_300,
        CASE
        	WHEN chw < 500 THEN r_500kg * 500
            WHEN chw >= 500 THEN r_500kg * chw
        END AS r_500,
        CASE
        	WHEN chw < 1000 THEN r_1000kg * 1000
            WHEN chw >= 1000 THEN r_1000kg * chw
        END AS r_1000,
        curr_code,
        acc_rates.acc_code,
        (@idx := @idx + 1) AS idx
    FROM air_freight.acc_rates
    LEFT JOIN air_freight.acc_products 
    	ON acc_rates.acc_code = acc_products.acc_code
    		AND acc_rates.product_name = acc_products.product_name
    LEFT JOIN air_freight.air_carriers
    	ON acc_products.acc_code = air_carriers.acc_code
    CROSS JOIN (SELECT @idx := 0) AS dummy
    WHERE acc_rates.airport_code = apc
    	AND acc_products.handling_code = ht;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_AirportName` (IN `apc` CHAR(3))  BEGIN
	SELECT airport_name
    FROM air_destinations.airports
    WHERE airport_code = apc;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_Airports` (IN `city` CHAR(3))  BEGIN
	SELECT airport_code
    FROM air_destinations.airports
    WHERE city_code = city;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_Airport_ByEntry` (IN `apc` CHAR(3))  BEGIN
	SELECT airport_code, airport_name, city_code, city_name, state_province, country_code
    FROM air_destinations.airports
    WHERE airport_code = apc;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_Cities` (IN `cc` CHAR(2))  BEGIN
	SELECT DISTINCT city_code
    FROM air_destinations.airports
    WHERE country_code = cc
	ORDER by city_code ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_CityName` (IN `city` CHAR(3))  BEGIN
	SELECT DISTINCT city_name, state_province
    FROM air_destinations.airports
    WHERE city_code = city;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_CountryCodes` (IN `rc` CHAR(3))  BEGIN
	SELECT country_code
    FROM air_destinations.countries
    WHERE region_code = rc
	ORDER by country_code ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_GhaRates` (IN `acc` CHAR(3), IN `ht` CHAR(2))  BEGIN
    SELECT
        gha_rates.gha_svc_code,
        gha_rates.rate_code,
        gha_rates.rate_limit,
        gha_rates.limit_mmt,
        gha_rates.rate_amount,
        gha_rates.rate_unit,
        gha_rates.rate_mmt,
        handling_agents.curr_code
    FROM air_freight.air_carriers
    INNER JOIN air_freight.gha_rates
        ON air_carriers.gha_code = gha_rates.gha_code
    INNER JOIN air_freight.handling_agents
        ON air_carriers.gha_code = handling_agents.gha_code
    WHERE air_carriers.acc_code = acc
        AND gha_rates.handling_code = ht;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Select_RegionCodes` (IN `tac` CHAR(4))  BEGIN
	SELECT region_code
    FROM air_destinations.regions
    WHERE area_code = tac
	ORDER by region_code ASC;
END$$

CREATE DEFINER=`root`@`localhost` PROCEDURE `pr_Update_PackingList` (IN `pc_length` INT, IN `pc_width` INT, IN `pc_height` INT, IN `pc_weight` DOUBLE, IN `ci_pieces` INT, IN `ci_is_dgr` BOOLEAN)  BEGIN
    INSERT INTO packing_list (length, width, height, weight, pieces, is_dgr)
    VALUES (pc_length, pc_width, pc_height, pc_weight, ci_pieces, ci_is_dgr);
END$$

DELIMITER ;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `packing_list`
--

CREATE TABLE `packing_list` (
  `item_number` int(11) NOT NULL,
  `length` int(11) NOT NULL DEFAULT 0,
  `width` int(11) NOT NULL DEFAULT 0,
  `height` int(11) NOT NULL DEFAULT 0,
  `weight` double NOT NULL DEFAULT 0,
  `pieces` int(11) NOT NULL DEFAULT 1,
  `is_dgr` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `packing_list`
--
ALTER TABLE `packing_list`
  ADD PRIMARY KEY (`item_number`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `packing_list`
--
ALTER TABLE `packing_list`
  MODIFY `item_number` int(11) NOT NULL AUTO_INCREMENT;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;

GRANT EXECUTE ON *.* TO `general`@`%`;

GRANT DROP ON `air_cargo`.`packing_list` TO `general`@`%`;
