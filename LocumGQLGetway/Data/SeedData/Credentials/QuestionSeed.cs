using LocumApp.Domain.Enums;
using LocumApp.Domain.Models.Credentials;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LocumGQLGateway.Data.SeedData.Credentials;

public class QuestionSeed : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        const int personalInformationCategoryId = 1;
        const int educationAndTrainingCategoryId = 2;
        const int licenceAndCertsCategoryId = 2;

        builder.HasData(
            // Personal Information
            new Question
            {
                Id = 1,
                CategoryId = personalInformationCategoryId,
                Text = "NPI",
                HelpText = "Enter your 10-digit National Provider Identifier (NPI).",
                DataType = QuestionDataType.Text,
                SortOrder = 1,
                RegexValidation = "^\\d{3}[- ]?\\d{3}[- ]?\\d{4}$\n"
            },
            new Question
            {
                Id = 2,
                CategoryId = personalInformationCategoryId,
                Text = "SSN",
                HelpText = "Enter your 9-digit Social Security Number (format: XXX-XX-XXXX).",
                DataType = QuestionDataType.Text,
                SortOrder = 2,
                RegexValidation = "^(?!000|666|9\\d{2})\\d{3}-(?!00)\\d{2}-(?!0000)\\d{4}$\n"
            },

            // Education and Training
            new Question
            {
                Id = 3,
                CreatedById = 1,
                CategoryId = educationAndTrainingCategoryId,
                Text = "Are you authorized to work in the U.S.?",
                HelpText = "Required to determine eligibility for job opportunities.",
                DataType = QuestionDataType.Boolean,
                SortOrder = 1
            },
            new Question
            {
                Id = 4,
                CreatedById = 1,
                CategoryId = educationAndTrainingCategoryId,
                Text = "Medical School Name",
                HelpText = "Enter the name of the medical school from which you graduated.",
                DataType = QuestionDataType.Text,
                SortOrder = 2
            },
            new Question
            {
                Id = 5,
                CreatedById = 1,
                CategoryId = educationAndTrainingCategoryId,
                Text = "City",
                HelpText = "Enter the city where your medical school is located.",
                DataType = QuestionDataType.Text,
                SortOrder = 3
            },
            new Question
            {
                Id = 6,
                CreatedById = 1,
                CategoryId = educationAndTrainingCategoryId,
                Text = "State",
                HelpText =
                    "Select the state where your medical school is located or where you are licensed to practice.",
                DataType = QuestionDataType.MultipleChoice,
                SortOrder = 4
            },
            new Question
            {
                Id = 7,
                CategoryId = licenceAndCertsCategoryId, // Replace with actual Category ID for "State Licenses"
                Text = "State",
                HelpText = "Select the U.S. state where the license is issued.",
                DataType = QuestionDataType.MultipleChoice,
                SortOrder = 1
            },
            new Question
            {
                Id = 8,
                CategoryId = licenceAndCertsCategoryId,
                Text = "License Number",
                HelpText = "Enter the full license number exactly as shown on the license.",
                DataType = QuestionDataType.Text,
                SortOrder = 2
            },
            new Question
            {
                Id = 9,
                CategoryId = licenceAndCertsCategoryId,
                Text = "Patients Seen (%)",
                HelpText = "Enter the percentage of patients you see in this state.",
                DataType = QuestionDataType.Number,
                SortOrder = 3,
                RegexValidation =
                    @"^(100(\.0{1,2})?|(\d{1,2}(\.\d{1,2})?))$" // Validates 0–100 with up to 2 decimal places
            }
        );
    }
}