using Newtonsoft.Json;

namespace OpenFoodFactsCSharp.Models
{
    public class Product
    {
        [JsonProperty("_id")] public string Id { get; set; }

        [JsonProperty("languages_codes")] public LanguagesCodes LanguagesCodes { get; set; }

        [JsonProperty("nutrient_levels")] public NutrientLevels NutrientLevels { get; set; }

        [JsonProperty("selected_images")] public SelectedImages SelectedImages { get; set; }

        [JsonProperty("additives_n")] public int? AdditivesN { get; set; }

        [JsonProperty("additives_old_n")] public int? AdditivesOldN { get; set; }

        [JsonProperty("additives_original_tags")]
        public string[] AdditivesOriginalTags { get; set; }

        [JsonProperty("additives_old_tags")] public string[] AdditivesOldTags { get; set; }

        [JsonProperty("additives_prev_original_tags")]
        public string[] AdditivesPrevOriginalTags { get; set; }

        [JsonProperty("additives_debug_tags")] public string[] AdditivesDebugTags { get; set; }

        [JsonProperty("additives_tags")] public string[] AdditivesTags { get; set; }

        [JsonProperty("allergens_from_ingredients")]
        public string AllergensFromIngredients { get; set; }

        [JsonProperty("allergens_from_user")] public string AllergensFromUser { get; set; }

        [JsonProperty("allergens_hierarchy")] public string[] AllergensHierarchy { get; set; }

        [JsonProperty("allergens_lc")] public string AllergensLc { get; set; }

        [JsonProperty("allergens_tags")] public string[] AllergensTags { get; set; }

        [JsonProperty("amino_acids_prev_tags")]
        public string[] AminoAcidsPrevTags { get; set; }

        [JsonProperty("amino_acids_tags")] public string[] AminoAcidsTags { get; set; }

        public string Brands { get; set; }

        [JsonProperty("brands_debug_tags")] public string[] BrandsDebugTags { get; set; }

        [JsonProperty("brands_tags")] public string[] BrandsTags { get; set; }

        [JsonProperty("carbon_footprint_percent_of_known_ingredients")]
        public string CarbonFootprintPercentOfKnownIngredients { get; set; }

        [JsonProperty("carbon_footprint_from_known_ingredients_debug")]
        public string CarbonFootprintFromKnownIngredientsDebug { get; set; }

        [JsonProperty("categories_hierarchy")] public string[] CategoriesHierarchy { get; set; }

        [JsonProperty("categories_lc")] public string CategoriesLc { get; set; }

        [JsonProperty("categories_properties_tags")]
        public string[] CategoriesPropertiesTags { get; set; }

        [JsonProperty("categories_tags")] public string[] CategoriesTags { get; set; }

        [JsonProperty("checkers_tags")] public string[] CheckersTags { get; set; }

        [JsonProperty("cities_tags")] public string[] CitiesTags { get; set; }

        [JsonProperty("codes_tags")] public string[] CodesTags { get; set; }

        [JsonProperty("compared_to_category")] public string ComparedToCategory { get; set; }

        [JsonProperty("completed_t")] public long? CompletedT { get; set; }

        [JsonProperty("conservation_conditions")]
        public string ConservationConditions { get; set; }

        [JsonProperty("countries_hierarchy")] public string[] CountriesHierarchy { get; set; }

        [JsonProperty("countries_lc")] public string CountriesLc { get; set; }

        [JsonProperty("countries_debug_tags")] public string[] CountriesDebugTags { get; set; }

        [JsonProperty("countries_tags")] public string[] CountriesTags { get; set; }

        [JsonProperty("correctors_tags")] public string[] CorrectorsTags { get; set; }

        [JsonProperty("created_t")] public long? CreatedT { get; set; }

        [JsonProperty("data_quality_bugs_tags")]
        public string[] DataQualityBugsTags { get; set; }

        [JsonProperty("data_quality_errors_tags")]
        public string[] DataQualityErrorsTags { get; set; }

        [JsonProperty("data_quality_info_tags")]
        public string[] DataQualityInfoTags { get; set; }

        [JsonProperty("data_quality_tags")] public string[] DataQualityTags { get; set; }

        [JsonProperty("data_quality_warnings_tags")]
        public string[] DataQualityWarningsTags { get; set; }

        [JsonProperty("data_sources")] public string DataSources { get; set; }

        [JsonProperty("data_sources_tags")] public string[] DataSourcesTags { get; set; }

        [JsonProperty("debug_param_sorted_langs")]
        public string[] DebugParamSortedLangs { get; set; }

        [JsonProperty("editors_tags")] public string[] EditorsTags { get; set; }

        [JsonProperty("emb_codes")] public string EmbCodes { get; set; }

        [JsonProperty("emb_codes_debug_tags")] public string[] EmbCodesDebugTags { get; set; }

        [JsonProperty("emb_codes_orig")] public string EmbCodesOrig { get; set; }

        [JsonProperty("emb_codes_tags")] public string[] EmbCodesTags { get; set; }

        [JsonProperty("entry_dates_tags")] public string[] EntryDatesTags { get; set; }

        [JsonProperty("expiration_date")] public string ExpirationDate { get; set; }

        [JsonProperty("expiration_date_debug_tags")]
        public string[] ExpirationDateDebugTags { get; set; }

        [JsonProperty("fruits-vegetables-nuts_100g_estimate")]
        public int? FruitsVegetablesNuts100GEstimate { get; set; }

        [JsonProperty("generic_name")] public string GenericName { get; set; }

        [JsonProperty("image_front_small_url")]
        public string ImageFrontSmallUrl { get; set; }

        [JsonProperty("image_front_thumb_url")]
        public string ImageFrontThumbUrl { get; set; }

        [JsonProperty("image_front_url")] public string ImageFrontUrl { get; set; }

        [JsonProperty("image_ingredients_url")]
        public string ImageIngredientsUrl { get; set; }

        [JsonProperty("image_ingredients_small_url")]
        public string ImageIngredientsSmallUrl { get; set; }

        [JsonProperty("image_ingredients_thumb_url")]
        public string ImageIngredientsThumbUrl { get; set; }

        [JsonProperty("image_nutrition_small_url")]
        public string ImageNutritionSmallUrl { get; set; }

        [JsonProperty("image_nutrition_thumb_url")]
        public string ImageNutritionThumbUrl { get; set; }

        [JsonProperty("image_nutrition_url")] public string ImageNutritionUrl { get; set; }

        [JsonProperty("image_small_url")] public string ImageSmallUrl { get; set; }

        [JsonProperty("image_thumb_url")] public string ImageThumbUrl { get; set; }

        [JsonProperty("image_url")] public string ImageUrl { get; set; }

        [JsonProperty("informers_tags")] public string[] InformersTags { get; set; }

        [JsonProperty("ingredients_analysis_tags")]
        public string[] IngredientsAnalysisTags { get; set; }

        [JsonProperty("ingredients_debug")] public string[] IngredientsDebug { get; set; }

        [JsonProperty("ingredients_from_or_that_may_be_from_palm_oil_n")]
        public int? IngredientsFromOrThatMayBeFromPalmOilN { get; set; }

        [JsonProperty("ingredients_from_palm_oil_tags")]
        public string[] IngredientsFromPalmOilTags { get; set; }

        [JsonProperty("ingredients_from_palm_oil_n")]
        public int? IngredientsFromPalmOilN { get; set; }

        [JsonProperty("ingredients_hierarchy")]
        public string[] IngredientsHierarchy { get; set; }

        [JsonProperty("ingredients_ids_debug")]
        public string[] IngredientsIdsDebug { get; set; }

        [JsonProperty("ingredients_n")] public int? IngredientsN { get; set; }

        [JsonProperty("ingredients_n_tags")] public string[] IngredientsNTags { get; set; }

        [JsonProperty("ingredients_original_tags")]
        public string[] IngredientsOriginalTags { get; set; }

        [JsonProperty("ingredients_tags")] public string[] IngredientsTags { get; set; }

        [JsonProperty("ingredients_text")] public string IngredientsText { get; set; }

        [JsonProperty("ingredients_text_debug")]
        public string IngredientsTextDebug { get; set; }

        [JsonProperty("ingredients_text_with_allergens")]
        public string IngredientsTextWithAllergens { get; set; }

        [JsonProperty("ingredients_that_may_be_from_palm_oil_n")]
        public int? IngredientsThatMayBeFromPalmOilN { get; set; }

        [JsonProperty("ingredients_that_may_be_from_palm_oil_tags")]
        public string[] IngredientsThatMayBeFromPalmOilTags { get; set; }

        [JsonProperty("interface_version_created")]
        public string InterfaceVersionCreated { get; set; }

        [JsonProperty("interface_version_modified")]
        public string InterfaceVersionModified { get; set; }

        [JsonProperty("_keywords")] public string[] Keywords { get; set; }

        [JsonProperty("known_ingredients_n")] public int? KnownIngredientsN { get; set; }

        [JsonProperty("labels_hierarchy")] public string[] LabelsHierarchy { get; set; }

        [JsonProperty("labels_lc")] public string LabelsLc { get; set; }

        [JsonProperty("labels_prev_hierarchy")]
        public string[] LabelsPrevHierarchy { get; set; }

        [JsonProperty("labels_prev_tags")] public string[] LabelsPrevTags { get; set; }

        [JsonProperty("labels_tags")] public string[] LabelsTags { get; set; }

        [JsonProperty("labels_debug_tags")] public string[] LabelsDebugTags { get; set; }

        [JsonProperty("lang_debug_tags")] public string[] LangDebugTags { get; set; }

        [JsonProperty("languages_hierarchy")] public string[] LanguagesHierarchy { get; set; }

        [JsonProperty("languages_tags")] public string[] LanguagesTags { get; set; }

        [JsonProperty("last_edit_dates_tags")] public string[] LastEditDatesTags { get; set; }

        [JsonProperty("last_editor")] public string LastEditor { get; set; }

        [JsonProperty("last_image_dates_tags")]
        public string[] LastImageDatesTags { get; set; }

        [JsonProperty("last_image_t")] public long? LastImageT { get; set; }

        [JsonProperty("last_modified_by")] public string LastModifiedBy { get; set; }

        [JsonProperty("last_modified_t")] public long? LastModifiedT { get; set; }

        [JsonProperty("link_debug_tags")] public string[] LinkDebugTags { get; set; }

        [JsonProperty("manufacturing_places")] public string ManufacturingPlaces { get; set; }

        [JsonProperty("manufacturing_places_debug_tags")]
        public string[] ManufacturingPlacesDebugTags { get; set; }

        [JsonProperty("manufacturing_places_tags")]
        public string[] ManufacturingPlacesTags { get; set; }

        [JsonProperty("max_imgid")] public string MaxImgid { get; set; }

        [JsonProperty("minerals_prev_tags")] public string[] MineralsPrevTags { get; set; }

        [JsonProperty("minerals_tags")] public string[] MineralsTags { get; set; }

        [JsonProperty("misc_tags")] public string[] MiscTags { get; set; }

        [JsonProperty("net_weight_unit")] public string NetWeightUnit { get; set; }

        [JsonProperty("net_weight_value")] public string NetWeightValue { get; set; }

        [JsonProperty("nutrition_data_per")] public string NutritionDataPer { get; set; }

        [JsonProperty("nutrition_score_warning_no_fruits_vegetables_nuts")]
        public int? NutritionScoreWarningNoFruitsVegetablesNuts { get; set; }

        [JsonProperty("no_nutrition_data")] public string NoNutritionData { get; set; }

        [JsonProperty("nova_group")] public string NovaGroup { get; set; }

        [JsonProperty("nova_groups")] public string NovaGroups { get; set; }

        [JsonProperty("nova_group_debug")] public string NovaGroupDebug { get; set; }

        [JsonProperty("nova_group_tags")] public string[] NovaGroupTags { get; set; }

        [JsonProperty("nova_groups_tags")] public string[] NovaGroupsTags { get; set; }

        [JsonProperty("nucleotides_prev_tags")]
        public string[] NucleotidesPrevTags { get; set; }

        [JsonProperty("nucleotides_tags")] public string[] NucleotidesTags { get; set; }

        [JsonProperty("nutrient_levels_tags")] public string[] NutrientLevelsTags { get; set; }

        [JsonProperty("nutrition_data")] public string NutritionData { get; set; }

        [JsonProperty("nutrition_data_per_debug_tags")]
        public string[] NutritionDataPerDebugTags { get; set; }

        [JsonProperty("nutrition_data_prepared")]
        public string NutritionDataPrepared { get; set; }

        [JsonProperty("nutrition_data_prepared_per")]
        public string NutritionDataPreparedPer { get; set; }

        [JsonProperty("nutrition_grades")] public string NutritionGrades { get; set; }

        [JsonProperty("nutriments")] public Nutriments Nutriments { get; set; }

        [JsonProperty("nutrition_score_beverage")]
        public int? NutritionScoreBeverage { get; set; }

        [JsonProperty("nutrition_score_debug")]
        public string NutritionScoreDebug { get; set; }

        [JsonProperty("nutrition_score_warning_no_fiber")]
        public int? NutritionScoreWarningNoFiber { get; set; }

        [JsonProperty("nutrition_grades_tags")]
        public string[] NutritionGradesTags { get; set; }

        [JsonProperty("origins_debug_tags")] public string[] OriginsDebugTags { get; set; }

        [JsonProperty("origins_tags")] public string[] OriginsTags { get; set; }

        [JsonProperty("other_information")] public string OtherInformation { get; set; }

        [JsonProperty("other_nutritional_substances_tags")]
        public string[] OtherNutritionalSubstancesTags { get; set; }

        [JsonProperty("packaging_debug_tags")] public string[] PackagingDebugTags { get; set; }

        [JsonProperty("ecoscore_data")] public EcoscoreData EcoscoreData { get; set; }

        [JsonProperty("packaging_tags")] public string[] PackagingTags { get; set; }

        [JsonProperty("photographers_tags")] public string[] PhotographersTags { get; set; }

        [JsonProperty("pnns_groups_1")] public string PnnsGroups1 { get; set; }

        [JsonProperty("pnns_groups_2")] public string PnnsGroups2 { get; set; }

        [JsonProperty("pnns_groups_1_tags")] public string[] PnnsGroups1Tags { get; set; }

        [JsonProperty("pnns_groups_2_tags")] public string[] PnnsGroups2Tags { get; set; }

        [JsonProperty("popularity_key")] public long? PopularityKey { get; set; }

        [JsonProperty("producer_version_id")] public string ProducerVersionId { get; set; }

        [JsonProperty("product_name")] public string ProductName { get; set; }

        [JsonProperty("product_quantity")] public string ProductQuantity { get; set; }

        [JsonProperty("purchase_places")] public string PurchasePlaces { get; set; }

        [JsonProperty("purchase_places_debug_tags")]
        public string[] PurchasePlacesDebugTags { get; set; }

        [JsonProperty("purchase_places_tags")] public string[] PurchasePlacesTags { get; set; }

        [JsonProperty("quality_tags")] public string[] QualityTags { get; set; }

        [JsonProperty("quantity_debug_tags")] public string[] QuantityDebugTags { get; set; }

        [JsonProperty("recycling_instructions_to_discard")]
        public string RecyclingInstructionsToDiscard { get; set; }

        [JsonProperty("serving_quantity")] public string ServingQuantity { get; set; }

        [JsonProperty("serving_size")] public string ServingSize { get; set; }

        [JsonProperty("serving_size_debug_tags")]
        public string[] ServingSizeDebugTags { get; set; }

        [JsonProperty("states_hierarchy")] public string[] StatesHierarchy { get; set; }

        [JsonProperty("states_tags")] public string[] StatesTags { get; set; }

        [JsonProperty("stores_debug_tags")] public string[] StoresDebugTags { get; set; }

        [JsonProperty("stores_tags")] public string[] StoresTags { get; set; }

        [JsonProperty("traces_from_ingredients")]
        public string TracesFromIngredients { get; set; }

        [JsonProperty("traces_hierarchy")] public string[] TracesHierarchy { get; set; }

        [JsonProperty("traces_debug_tags")] public string[] TracesDebugTags { get; set; }

        [JsonProperty("traces_from_user")] public string TracesFromUser { get; set; }

        [JsonProperty("traces_lc")] public string TracesLc { get; set; }

        [JsonProperty("traces_tags")] public string[] TracesTags { get; set; }

        [JsonProperty("unknown_ingredients_n")]
        public int? UnknownIngredientsN { get; set; }

        [JsonProperty("unknown_nutrients_tags")]
        public string[] UnknownNutrientsTags { get; set; }

        [JsonProperty("update_key")] public string UpdateKey { get; set; }

        [JsonProperty("vitamins_prev_tags")] public string[] VitaminsPrevTags { get; set; }

        [JsonProperty("vitamins_tags")] public string[] VitaminsTags { get; set; }
    }
}