using StockLedge.Domain.Exceptions;

namespace StockLedge.Domain.Uoms
{
	public class UnitOfMeasureEntity
	{
		public long Id { get; private set; }
		public string Name { get; private set; } = string.Empty;

		public string Code { get; private set; } = string.Empty;

		public decimal Multiplier { get; private set; }

		public bool IsBase { get; private set; }

		public bool IsActive { get; private set; } = true;

		public long UnitOfMeasureGroupId { get; private set; }

		public UnitOfMeasureGroupEntity UomGroup { get; private set; } = null!;

		private UnitOfMeasureEntity()
		{
		}

		internal static UnitOfMeasureEntity CreateBaseUnit(
			string name,
			string code,
			UnitOfMeasureGroupEntity uomGroup)
		{
			ValidateName(name);
			ValidateCode(code);

			return new UnitOfMeasureEntity
			{
				Name = name.Trim(),
				Code = code.Trim().ToUpperInvariant(),
				Multiplier = 1,
				IsBase = true,
				UomGroup = uomGroup,
				UnitOfMeasureGroupId = uomGroup.Id
			};
		}

		internal static UnitOfMeasureEntity Create(
			string name,
			string code,
			decimal multiplier,
			UnitOfMeasureGroupEntity uomGroup)
		{
			ValidateName(name);
			ValidateCode(code);
			ValidateMultiplier(multiplier);

			return new UnitOfMeasureEntity
			{
				Name = name.Trim(),
				Code = code.Trim().ToUpperInvariant(),
				Multiplier = multiplier,
				IsBase = false,
				UomGroup = uomGroup,
				UnitOfMeasureGroupId = uomGroup.Id
			};
		}

		public void Deactivate()
		{
			if (IsBase)
			{
				throw new BusinessRuleViolationException(
					"uom.base_unit_deactivation_not_allowed",
					"The base unit cannot be deactivated independently."
				);
			}

			if (!IsActive)
			{
				return;
			}

			IsActive = false;
		}

		private static void ValidateName(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
			{
				throw new BusinessRuleViolationException(
					"uom.name_required",
					"Unit name is required."
				);
			}
		}

		private static void ValidateCode(string code)
		{
			if (string.IsNullOrWhiteSpace(code))
			{
				throw new BusinessRuleViolationException(
					"uom.code_required",
					"Unit code is required."
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
