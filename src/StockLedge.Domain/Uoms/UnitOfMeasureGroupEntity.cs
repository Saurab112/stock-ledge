using StockLedge.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace StockLedge.Domain.Uoms
{
	public class UnitOfMeasureGroupEntity
	{
		private UnitOfMeasureGroupEntity()
		{
		}
		private readonly List<UnitOfMeasureEntity> _units = [];

		public long Id { get; private set; }

		public string Name { get; private set; } = string.Empty;

		public string Code { get; private set; } = string.Empty;

		public bool IsActive { get; private set; } = true;

		public IReadOnlyCollection<UnitOfMeasureEntity> Units => _units.AsReadOnly();

		public UnitOfMeasureEntity BaseUnit => _units.Single(unit => unit.IsBase);


		public static UnitOfMeasureGroupEntity Create(
		string name,
		string code,
		string baseUnitName,
		string baseUnitCode)
		{
			ValidateName(name);
			ValidateCode(code);
			ValidateName(baseUnitName);
			ValidateCode(baseUnitCode);

			var group = new UnitOfMeasureGroupEntity
			{
				Name = name.Trim(),
				Code = code.Trim().ToUpperInvariant()
			};

			var baseUnit = UnitOfMeasureEntity.CreateBaseUnit(
				baseUnitName,
				baseUnitCode,
				group
			);

			group._units.Add(baseUnit);

			return group;
		}

		public UnitOfMeasureEntity AddUnit(
			string name,
			string code,
			decimal multiplier)
		{
			EnsureActive();

			ValidateName(name);
			ValidateCode(code);
			ValidateMultiplier(multiplier);

			EnsureUnitCodeIsUnique(code);
			EnsureUnitNameIsUnique(name);

			var unit = UnitOfMeasureEntity.Create(
				name,
				code,
				multiplier,
				this
			);

			_units.Add(unit);

			return unit;
		}

		public void Deactivate()
		{
			EnsureActive();

			IsActive = false;
		}

		private void EnsureActive()
		{
			if (!IsActive)
			{
				throw new BusinessRuleViolationException(
					"uom_group.inactive",
					"Cannot modify an inactive UOM Group."
				);
			}
		}

		private void EnsureUnitCodeIsUnique(string code)
		{
			if (_units.Any(unit =>
				unit.Code.Equals(
					code.Trim(),
					StringComparison.OrdinalIgnoreCase)))
			{
				throw new BusinessRuleViolationException(
					"uom_group.duplicate_unit_code",
					$"Unit code '{code}' already exists in this group."
				);
			}
		}

		private void EnsureUnitNameIsUnique(string name)
		{
			if (_units.Any(unit =>
				unit.Name.Equals(
					name.Trim(),
					StringComparison.OrdinalIgnoreCase)))
			{
				throw new BusinessRuleViolationException(
					"uom_group.duplicate_unit_name",
					$"Unit name '{name}' already exists in this group."
				);
			}
		}

		private static void ValidateName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new BusinessRuleViolationException(
					"uom_group.name_required",
					"Name is required."
				);
			}
		}

		private static void ValidateCode(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				throw new BusinessRuleViolationException(
					"uom_group.code_required",
					"Code is required."
				);
			}
		}

		private static void ValidateMultiplier(decimal multiplier)
		{
			if (multiplier <= 0)
			{
				throw new BusinessRuleViolationException(
					"uom.multiplier_not_positive",
					"Multiplier must be greater than zero."
				);
			}

			if (multiplier == 1)
			{
				throw new BusinessRuleViolationException(
					"uom.non_base_multiplier_one",
					"A non-base unit cannot have a multiplier of 1."
				);
			}
		}
	}
}
